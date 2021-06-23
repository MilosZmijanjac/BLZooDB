-- MySQL Script generated by MySQL Workbench
-- Sun May 16 07:01:16 2021
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema blzoodb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `blzoodb` ;

-- -----------------------------------------------------
-- Schema blzoodb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `blzoodb` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `blzoodb` ;
USE `blzoodb` ;

-- -----------------------------------------------------
-- procedure AzurirajHranu
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`AzurirajHranu`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AzurirajHranu`(IN h_id INTEGER,IN kol INTEGER)
BEGIN
update hrana set stanje=stanje+kol where hrana.hrana_id=h_id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure AzurirajLijekove
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`AzurirajLijekove`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AzurirajLijekove`(IN l_id INTEGER,IN kolicina INTEGER)
BEGIN
UPDATE lijek SET stanje = stanje +kolicina WHERE lijek_id=l_id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure AzurirajProizvode
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`AzurirajProizvode`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AzurirajProizvode`(IN id INTEGER,IN velicina VARCHAR(10),IN kolicina INTEGER)
BEGIN
UPDATE proizvod SET stanje = stanje+kolicina WHERE proizvod_id=id AND proizvod_velicina=velicina;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure AzurirajZivotinje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`AzurirajZivotinje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AzurirajZivotinje`(IN id INTEGER,IN stanje VARCHAR(45),IN broj INTEGER)
BEGIN
update zivotinja set zivotinja.zdravstveno_stanje=stanje, broj_hranjenja_dnevno=broj where zivotinja_id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviCuvaraZivotinje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviCuvaraZivotinje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviCuvaraZivotinje`(IN id INTEGER)
BEGIN
SELECT * FROM zaposleni JOIN BRINE_SE_O ON zaposleni.zaposleni_id=BRINE_SE_O.cuvar_id WHERE BRINE_SE_O.zivotinja_id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviCuvariObavjesti
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviCuvariObavjesti`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviCuvariObavjesti`(IN c_id INTEGER)
BEGIN
SELECT * FROM CuvariObavjestiView WHERE cuvar_id =c_id ORDER BY datum DESC;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviHranu
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviHranu`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviHranu`()
BEGIN
SELECT * FROM hrana;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviHranuOdZivotinje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviHranuOdZivotinje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviHranuOdZivotinje`(IN id INTEGER)
BEGIN
SELECT * FROM hranazivotinjeview WHERE zivotinja_id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviInformacijeOCuvarima
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviInformacijeOCuvarima`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviInformacijeOCuvarima`()
BEGIN
SELECT * FROM cuvariinfoview;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviInformacijeOZaposlenom
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviInformacijeOZaposlenom`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviInformacijeOZaposlenom`(IN id INTEGER,OUT odjel_id INTEGER,OUT isMenadzer INTEGER,OUT isCuvar INTEGER)
BEGIN
		SELECT odjeljenje_id INTO odjel_id FROM zaposleni WHERE  zaposleni.zaposleni_id=id ;
        SELECT COUNT(*) INTO isMenadzer FROM odjeljenje WHERE rukovodilac_id = id;
        SELECT COUNT(*) INTO isCuvar FROM BRINE_SE_O WHERE cuvar_id = id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviLijekoveOdZivotinje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviLijekoveOdZivotinje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviLijekoveOdZivotinje`(IN id INTEGER)
BEGIN
SELECT * FROM zivotinjanalijecenjuview WHERE zivotinja_id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviNarudzbeOdDo
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviNarudzbeOdDo`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviNarudzbeOdDo`(IN od TIMESTAMP,IN do TIMESTAMP)
BEGIN
SELECT narudzba.*, proizvod.proizvod_naziv, proizvod.proizvod_velicina FROM narudzba JOIN proizvod ON narudzba.proizvod_id=proizvod.proizvod_id WHERE datum_narudzbe BETWEEN od AND do;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviObavjestiLijekovi
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviObavjestiLijekovi`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviObavjestiLijekovi`()
BEGIN
select * from veterinarlijekoviobavjestiview;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviObavjestiTrgovine
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviObavjestiTrgovine`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviObavjestiTrgovine`(IN id INTEGER)
BEGIN
SELECT * FROM trgovinaobavjestiview WHERE rukovodilac_id =id ORDER BY datum_generisanja ASC;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviObavjestiVeterinara
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviObavjestiVeterinara`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviObavjestiVeterinara`()
BEGIN
select * from veterinarobavjestiview;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviOdjeljenja
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviOdjeljenja`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviOdjeljenja`()
BEGIN
select * from odjeljenje;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviProdaneProizvode
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviProdaneProizvode`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviProdaneProizvode`(IN od TIMESTAMP,IN do TIMESTAMP)
BEGIN
SELECT blzoodb.narudzba.proizvod_id, blzoodb.proizvod.proizvod_naziv, COUNT(blzoodb.narudzba.proizvod_id) AS kolicina FROM blzoodb.narudzba JOIN blzoodb.proizvod ON blzoodb.narudzba.proizvod_id = blzoodb.proizvod.proizvod_id WHERE datum_narudzbe BETWEEN od AND do GROUP BY proizvod_id ORDER BY COUNT(proizvod_id) DESC;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviProdaneUlazniceOdDo
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviProdaneUlazniceOdDo`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviProdaneUlazniceOdDo`(IN od TIMESTAMP,IN do TIMESTAMP)
BEGIN

SELECT blzoodb.narudzba.proizvod_id, blzoodb.proizvod.proizvod_naziv, COUNT(blzoodb.narudzba.proizvod_id) AS kolicina FROM blzoodb.narudzba JOIN blzoodb.proizvod ON blzoodb.narudzba.proizvod_id = blzoodb.proizvod.proizvod_id WHERE datum_narudzbe BETWEEN od AND do AND blzoodb.narudzba.proizvod_id <= 1000006 GROUP BY proizvod_id ORDER BY COUNT(proizvod_id) DESC;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviProizvode
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviProizvode`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviProizvode`()
BEGIN
SELECT * FROM proizvod WHERE (stanje > 0 OR stanje IS NULL) AND trgovina_id!=11 ORDER BY trgovina_id, proizvod_id;

END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviSlobodneCuvare
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviSlobodneCuvare`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviSlobodneCuvare`(IN id INTEGER)
BEGIN
SELECT * FROM zaposleni WHERE zaposleni.zaposleni_id NOT IN (SELECT BRINE_SE_O.cuvar_id FROM BRINE_SE_O WHERE BRINE_SE_O.zivotinja_id=id) AND zaposleni.odjeljenje_id=15;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviSmjestaje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviSmjestaje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviSmjestaje`()
BEGIN
select smjestaj_id,smjestaj_naziv from smjestaj;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviUkupanPrihodOdDo
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviUkupanPrihodOdDo`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviUkupanPrihodOdDo`(IN od TIMESTAMP,IN do TIMESTAMP,out prihod INTEGER)
BEGIN
 SELECT SUM(ukupna_cijena) into prihod FROM narudzba WHERE datum_narudzbe BETWEEN od AND do ;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviUlaznice
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviUlaznice`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviUlaznice`()
BEGIN
SELECT * FROM proizvod where trgovina_id=11;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviZaposlenogPoID
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviZaposlenogPoID`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviZaposlenogPoID`(IN id INTEGER)
BEGIN
select * from `zaposleni` 
        where zaposleni_id = id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DobaviZivotinje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DobaviZivotinje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DobaviZivotinje`()
BEGIN
select * from zivotinja;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DodajHranu
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DodajHranu`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DodajHranu`(IN hrana_naziv VARCHAR(50),IN stanje INTEGER, IN potrebno_stanje INTEGER)
BEGIN
INSERT INTO hrana (hrana_naziv, stanje, potrebno_stanje) VALUES (hrana_naziv,stanje,potrebno_stanje);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DodajLijek
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DodajLijek`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DodajLijek`(IN lijek_naziv VARCHAR(45),IN stanje INTEGER,IN potrebno_stanje INTEGER)
BEGIN
INSERT INTO lijek (lijek_naziv, stanje, potrebno_stanje) VALUES (lijek_naziv, stanje, potrebno_stanje);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DodajNoviProizvod
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DodajNoviProizvod`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DodajNoviProizvod`(IN id INTEGER,IN velicina VARCHAR(10),IN ime VARCHAR(50),IN shop_id INTEGER,IN cijena DECIMAL(5,2),IN kolicina INTEGER,IN slika VARCHAR(50),IN potrebna_kolicina INTEGER,IN shop_kat VARCHAR(40))
BEGIN
INSERT INTO proizvod (proizvod_id,proizvod_naziv,proizvod_velicina,cijena, stanje, potrebno_stanje,putanja_do_slike, trgovina_id,kategorija_trgovine) VALUES (id,ime,velicina,cijena,kolicina,potrebna_kolicina,slika,shop_id,shop_kat);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DodajZaposlenog
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DodajZaposlenog`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DodajZaposlenog`(IN z_lozinka VARCHAR(45),IN z_ime VARCHAR(45),IN z_prezime VARCHAR(45), IN z_nadredjeni_id INTEGER, IN z_odjeljenje_id INTEGER,OUT z_id INTEGER)
BEGIN
INSERT INTO `blzoodb`.`zaposleni`(`lozinka`,`ime`,`prezime`,`nadredjeni_id`,`odjeljenje_id`)
VALUES (z_lozinka,z_ime,z_prezime,z_nadredjeni_id,z_odjeljenje_id);
SELECT LAST_INSERT_ID() INTO z_id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DodajZivotinju
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DodajZivotinju`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DodajZivotinju`(IN ime varchar(50),IN vrsta varchar(30),IN dat_rodj timestamp,in spol varchar(30),in smjestaj_id integer,in zdrav_stanje varchar(30),in tip_ish varchar(30),in broj_hranjenja integer, in slika varchar(50))
BEGIN
insert into zivotinja(zivotinja_ime,zivotinja_vrsta,datum_prijema,datum_rodjenja,spol,smjestaj_id,zdravstveno_stanje,tip_ishrane,broj_hranjenja_dnevno,putanja_do_slike) values(ime,vrsta,current_date(),dat_rodj,spol,smjestaj_id,zdrav_stanje,tip_ish,broj_hranjenja,slika);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure DodijeliZivotinjeCuvaru
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`DodijeliZivotinjeCuvaru`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DodijeliZivotinjeCuvaru`(IN c_id INTEGER,IN z_id INTEGER)
BEGIN
INSERT INTO BRINE_SE_O(cuvar_id,zivotinja_id) values(c_id,z_id);
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure isMenadzer
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`isMenadzer`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `isMenadzer`(IN id INTEGER,OUT isMenadzer INTEGER)
BEGIN
select count(*) into isMenadzer from odjeljenje where rukovodilac_id = id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure Login
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`Login`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `Login`(IN id INTEGER,IN pass VARCHAR(255),OUT result INTEGER)
BEGIN
select count(*) into result from `zaposleni` 
        where zaposleni_id = id and lozinka=pass;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure ObrisiCuvaraZivotinje
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`ObrisiCuvaraZivotinje`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObrisiCuvaraZivotinje`(IN c_id INTEGER,IN z_id INTEGER)
BEGIN
delete from BRINE_SE_O where BRINE_SE_O.zivotinja_id=z_id and BRINE_SE_O.cuvar_id=c_id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure ObrisiZaposlenog
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`ObrisiZaposlenog`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObrisiZaposlenog`(IN id INTEGER)
BEGIN
DELETE FROM zaposleni WHERE zaposleni_id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure ObrisiZivotinju
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`ObrisiZivotinju`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `ObrisiZivotinju`(IN id INTEGER)
BEGIN
delete from zivotinja where zivotinja_id=id;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure PromjeniLozinku
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`PromjeniLozinku`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PromjeniLozinku`(IN id INTEGER,IN oldPass VARCHAR(255),IN newPass VARCHAR(255))
BEGIN
UPDATE zaposleni SET zaposleni.lozinka=newPass WHERE zaposleni_id=id AND lozinka=oldPass;
END$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure PropisiLijekZivotinji
-- -----------------------------------------------------

USE `blzoodb`;
DROP procedure IF EXISTS `blzoodb`.`PropisiLijekZivotinji`;

DELIMITER $$
USE `blzoodb`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `PropisiLijekZivotinji`(IN lijek_id INTEGER,IN zivotinja_id INTEGER ,IN doza_u_mg INTEGER,IN doziranje VARCHAR(50),IN trajanje_lijecenja_u_danima INTEGER,IN bolest VARCHAR(100))
BEGIN
INSERT INTO `blzoodb`.`zivotinja_lijecenje`
(`lijek_id`,`zivotinja_id`,`doza_u_mg`,`doziranje`,`datum_propisivanja`,`trajanje_lijecenja_u_danima`,`bolest`)
VALUES
(lijek_id,zivotinja_id,doza_u_mg,doziranje,DATE(NOW()),trajanje_lijecenja_u_danima,bolest);
END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
