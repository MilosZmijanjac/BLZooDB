-- MySQL Script generated by MySQL Workbench
-- Tue May 11 17:54:25 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema blzoodb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema blzoodb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `blzoodb` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `blzoodb` ;
USE `blzoodb`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER = CURRENT_USER TRIGGER `blzoodb`.`zivotinja_ZDRAVSTVENO_STANJE_PROMJENA` AFTER UPDATE ON `zivotinja` FOR EACH ROW
BEGIN
DECLARE cuvar INT;
	DECLARE exit_loop BOOLEAN;
	DECLARE cuvari CURSOR FOR SELECT cuvar_id FROM BRINE_SE_O WHERE NEW.zivotinja_id = BRINE_SE_O.zivotinja_id;
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET exit_loop=TRUE;
    IF 
    NEW.`zdravstveno_stanje` != OLD.`zdravstveno_stanje` 
    THEN
		OPEN cuvari;
        myLoop: LOOP
        FETCH cuvari INTO cuvar;
        IF exit_loop THEN 
			CLOSE cuvari;
            LEAVE myLoop;
		END IF;
		INSERT INTO CUVAR_OBAVJEST VALUES(NEW.zivotinja_id, cuvar, (SELECT DATE(now())), NEW.zdravstveno_stanje);
	END LOOP myLoop;
	END IF;
END$$

USE `blzoodb`$$
CREATE DEFINER = CURRENT_USER TRIGGER `blzoodb`.`hrana_NISKO_STANJE` AFTER UPDATE ON `hrana` FOR EACH ROW
BEGIN
IF  -- ako je stanje 20% potrebnog stanja
    NEW.stanje < (0.2*NEW.potrebno_stanje) 
    AND
    (NEW.hrana_id, (SELECT rukovodilac_id FROM odjeljenje WHERE odjeljenje.odjeljenje_id = 12), DATE(now())) NOT IN (SELECT * FROM ZOO_ZALIHE_OBAVJESTI)
    THEN
		INSERT INTO ZOO_ZALIHE_OBAVJESTI VALUES(NEW.hrana_id, (SELECT rukovodilac_id FROM odjeljenje WHERE odjeljenje_id = 12), (SELECT DATE(now())));
	END IF;
END$$

USE `blzoodb`$$
CREATE DEFINER = CURRENT_USER TRIGGER `blzoodb`.`lijek_NISKO_STANJE` AFTER UPDATE ON `lijek` FOR EACH ROW
BEGIN
IF -- ako je stanje 20% potrebnog stanja
    NEW.stanje < (0.2*NEW.potrebno_stanje) 
    AND
    (NEW.lijek_id, (SELECT rukovodilac_id FROM odjeljenje WHERE odjeljenje.odjeljenje_id = 9), DATE(now())) NOT IN (SELECT * FROM ZOO_ZALIHE_OBAVJESTI)
    THEN
		INSERT INTO ZOO_ZALIHE_OBAVJESTI VALUES(NEW.lijek_id, (SELECT rukovodilac_id FROM odjeljenje WHERE odjeljenje_id = 9), (SELECT DATE(now())));
	END IF;
END$$

USE `blzoodb`$$
CREATE DEFINER = CURRENT_USER TRIGGER `blzoodb`.`proizvod_NISKO_STANJE` AFTER UPDATE ON `proizvod` FOR EACH ROW
BEGIN
IF 
    NEW.stanje < (0.2*NEW.potrebno_stanje) 
    AND
    (NEW.proizvod_id, NEW.proizvod_velicina, DATE(now())) NOT IN (SELECT TRGOVINA_ZALIHE_OBAVJESTI.proizvod_id, TRGOVINA_ZALIHE_OBAVJESTI.proizvod_velicina, TRGOVINA_ZALIHE_OBAVJESTI.datum_generisanja FROM TRGOVINA_ZALIHE_OBAVJESTI)
    THEN
		INSERT INTO TRGOVINA_ZALIHE_OBAVJESTI VALUES(NEW.proizvod_id, NEW.proizvod_velicina, (SELECT rukovodilac_id FROM odjeljenje WHERE NEW.trgovina_id = odjeljenje.odjeljenje_id) , (SELECT DATE(now())));
	END IF;
END$$

USE `blzoodb`$$
CREATE DEFINER = CURRENT_USER TRIGGER `blzoodb`.`narudzba_AFTER_INSERT` AFTER INSERT ON `narudzba` FOR EACH ROW
IF (SELECT proizvod.trgovina_id FROM proizvod WHERE proizvod.proizvod_id=NEW.proizvod_id AND proizvod.proizvod_velicina= NEW.proizvod_velicina) != 11
    THEN
		 UPDATE proizvod SET proizvod.stanje = proizvod.stanje - NEW.kolicina WHERE proizvod.proizvod_id = NEW.proizvod_id AND proizvod.proizvod_velicina= NEW.proizvod_velicina;
    END IF$$


DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;