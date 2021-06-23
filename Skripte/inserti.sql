use blzoodb;

-- INSERT HRANA

INSERT INTO `hrana` VALUES (1,'Kruh',1063,1000),(322691273,'Mrkva',909,1000),(422245607,'Haringa',700,1000),
(792905148,'Banane',880,1000),(794122027,'Jabuke',900,1000),(804823626,'Zelena salata',1064,1000),
(835113132,'Keksi',900,1000),(839708572,'Peleti',900,1000),(1106475763,'Bale sijena',900,1000),
(1257629409,'Lignje',900,1000),(1298648319,'Skusa',900,1000),(1351705792,'Meso',900,1000),
(1491347236,'Skakavci',900,1000),(1531812139,'Kisne gliste',660,1000),(1770563148,'Brasnari',900,1000),
(1868590879,'Larve',900,1000),(1868820041,'Tuna',900,1000),(1899961941,'Borovnice',890,1000),(2022450965,'Kelj',900,1000),
(2123834211,'Misevi',548,1000),(2123834212,'Krekeri',150,1000),(2123834213,'Losos',150,1000),(2123834214,'Sardine',250,1000),
(2123834215,'Suncokretove sjemenke',250,1000),(2123834216,'Bobice',11798,5000),(2123834217,'Kokos',1500,2000),
(2123834218,'Susene alge',100,100),(2123834219,'Pasulj',100,100),(2123834220,'Voda',10000,10000);

-- INSERT ZA SMJESTAJ

INSERT INTO `smjestaj` VALUES (111111,'Africka suma',NULL,NULL,NULL),(111112,'Dzungla',NULL,NULL,NULL),(111113,'Kanjon',NULL,NULL,NULL),
(111114,'Kameni greben',NULL,NULL,NULL),(111115,'Bara za nilske konje','Habitat za dva nilska konja',24,NULL),(111116,'Africka suma',NULL,NULL,NULL),
(111117,'Kopno',NULL,NULL,NULL),(111118,'Artik',NULL,NULL,NULL),(111119,'Pustinja',NULL,NULL,NULL),(111120,'Prasuma',NULL,NULL,NULL),
(111121,'Mocvara',NULL,NULL,NULL),(111122,'Vodeni svijet',NULL,NULL,NULL);

use blzoodb;
INSERT INTO `odjeljenje` VALUES 
(2,'HR',NULL),
(7,'Trgovina',NULL),
(9,'Veterina',NULL),
(11,'Karte',NULL),
(15,'Cuvari',NULL);

-- INSERT ZA ZAPOSLENI
INSERT INTO `zaposleni` VALUES 
(10013,'password','Georgije','Boskovic',null,2),
(10003,'password','Nikola','Matic',10013,7),
(10006,'password','Danijel','Danilovic',10003,7),
(10008,'password','Nevena','Mitic',10013,9),
(10010,'password','Mitar','Bojanic',10013,15),
(10011,'password','Miroljub','Vuckovic',10010,15),
(10012,'password','Pavle','Mihajlovic',10010,15),
(10014,'password','Ivana','Jankovic',10010,15),
(10015,'password','Nikolina','Jokic',10008,9),
(10018,'password','Maja','Pantic',10003,7),
(10019,'password','Kristijan','Milicic',10013,11),
(10020,'password','Bogdan','Lazic',10013,11);

update odjeljenje set rukovodilac_id=10013 where odjeljenje_id=2;
update odjeljenje set rukovodilac_id=10003 where odjeljenje_id=7;
update odjeljenje set rukovodilac_id=10003 where odjeljenje_id=11;
update odjeljenje set rukovodilac_id=10008 where odjeljenje_id=9;
update odjeljenje set rukovodilac_id=10010 where odjeljenje_id=15;

use blzoodb;
INSERT INTO `lijek` VALUES 
(100001,'Prednisollone',94,100),(100002,'Xylazine: Injection Solution',101,100),(100003,'Amikacin',79,100),
(100004,'Atovaquone Oral Oil Suspension',99,100),(100005,'Pyrimethamine/ Sulfadiazine Capsule',99,100),
(100006,'Atenolol TWIST-A-TASTE Flavored Oral Gel',100,100),(100007,'Fluoxetine Oral Gel',340,100),
(100008,'PYRIMETHAMINE/FOLIC ACID: CAPSULE\n\n',99,100),(100009,'CALCIUM CHLORIDE/MAGNESIUM SULFATE',101,100),
(100010,'Tylenol',505,1000),(100011,'Advil',900,1000),(100012,'Gripa vakcina',130,1000),(100013,'Zyrtec',1000,1000),(100014,'Benadryl',100,1000);


use blzoodb;
INSERT INTO `proizvod` VALUES 
(1000000,'NA','Delfin Show karta',11,19.99,NULL,'ticket.png',NULL,'karta'),
 (1000001,'NA','Hranjenje zirafe karta',11,22.99,NULL,'ticket2.png',NULL,'karta'),
 (1000002,'NA','Voznja vozicem karta',11,9.99,NULL,'ticket.png',NULL,'karta'),
 (1000003,'NA','Voznja camcem karta',11,9.99,NULL,'ticket2.png',NULL,'karta'),
 (1000004,'NA','Domace zivotinje karta',11,9.99,NULL,'ticket.png',NULL,'karta'),
 (37378708,'NA','Jednogodisnje clanstvo',11,99.99,NULL,'membership.png',NULL,'karta'),
 (99307447,'S','Tigar majica',7,34.48,81,'tigertshirt.png',100,'odjeca'),
 (99307447,'M','Tigar majica',7,25.00,20,'tigertshirt.png',23,'odjeca'),
 (103874962,'XL','BLZoo majica',7,28.59,80,'zootshirt.png',100,'odjeca'),
 (309067027,'NA','Karta za jedno',11,13.72,NULL,'ticket.png',NULL,'karta'),
 (1189877359,'NA','Slonic igracka',7,14.49,50,'elephantplush.png',70,'igracke'),
(2057483647,'XS','Koala majica ',7,24.06,80,'koalatshirt.jpg',100,'odjeca'),
(2057483647,'S','Koala majica ',7,24.06,73,'koalatshirt.jpg',100,'odjeca'),
(2057483647,'M','Koala majica ',7,16.01,80,'koalatshirt.jpg',100,'odjeca'),
(2057483647,'L','Koala majica ',7,16.01,80,'koalatshirt.jpg',100,'odjeca'),
(2057483648,'XS','Lav majica',7,34.48,80,'lionshirt.jpg',100,'odjeca'),
(2057483648,'S','Lav majica',7,34.48,80,'lionshirt.jpg',100,'odjeca'),
(2057483648,'M','Lav majica',7,10.00,31,'lionshirt.jpg',30,'odjeca'),
(2057483652,'NA','Lav karta',11,24.99,NULL,'ticket.png',NULL,'karta');

use blzoodb;
INSERT INTO `TRGOVINA_ZALIHE_OBAVJESTI` VALUES 
(99307447,'S',10003,'2021-04-20'),
(103874962,'XL',10003,'2021-04-20'),
(2057483647,'XS',10003,'2021-04-20'),
(2057483647,'S',10003,'2021-04-20'),
(2057483647,'M',10003,'2021-04-20'),
(2057483647,'L',10003,'2021-04-20'),
(2057483648,'XS',10003,'2021-04-20'),
(2057483648,'S',10003,'2021-04-20'),
(1189877359,'NA',10003,'2021-05-10');

use blzoodb;
INSERT INTO `zivotinja` VALUES 
(47234,'Bill','Koza','2020-04-19','2016-04-01','M',111119,'zdrava','biljojed',4,'goat.jpg'),
(71138,'Kai','Lav','2020-04-19','2016-05-02','M',111117,'zdrava','mesojed',4,'lion.jpg'),
(107777487,'Hop','Leopard ','2017-06-21','2016-01-20','M',111113,'bolesna','mesojed',3,'leopard.jpg'),
(155344501,'Suzie','Anakonda','2019-03-05','2018-02-05','Z',111120,'gravidna','mesojed',3,'anaconda.jpg'),
(222252359,'Cherry','Bijela lisica','2016-07-02','2019-05-28','Z',111118,'zdrava','mesojed',4,'arctic-fox.jpg'),
(428427324,'Zeke','Zebra','2019-01-08','2017-01-31','M',111116,'zdrava',NULL,3,'zebra.jpg'),
(551854014,'Terri','Takin','2017-02-01','2017-04-03','Z',111116,'zdrava','biljojed',6,'takin.jpg'),
(641287356,'Jason','Orao','2019-08-07','2016-03-23','M',111117,'zdrava',NULL,3,'bateleur-eagle.jpg'),
(678157324,'Betty','Pcelarica','2018-04-08','2018-02-14','Z',111117,'zdrava',NULL,4,'bee-eater.jpg');

use blzoodb;
INSERT INTO `ZIVOTINJA_ISHRANA` VALUES 
(47234,1,20,2),
(47234,322691273,30,2),
(47234,794122027,30,2),
(47234,1899961941,10,2),
(71138,794122027,30,6),
(107777487,322691273,30,3),
(155344501,422245607,30,3),
(222252359,792905148,30,3),
(428427324,794122027,30,3),
(551854014,804823626,30,3),
(641287356,835113132,30,3),
(641287356,2123834216,30,5),
(678157324,839708572,30,3),
(678157324,2123834216,30,6);

INSERT INTO `ZIVOTINJA_LIJECENJE` VALUES 
(47234,100001,2,'tri puta dnevno','2020-04-19',2,'Dijabetes'),
(107777487,100001,3,'jednom dnevno','2020-04-19',60,'Srcani crvi'),
(107777487,100002,3,'jednom sedmicno','2020-04-19',90,'Srcani crvi'),
(107777487,100003,3,'jednom mjesecno','2020-04-19',30,'Srcani crvi'),
(155344501,100006,2,'dva puta dnevno','2020-04-19',2,'Dijabetes'),
(155344501,100010,5,'jednom dnevno','2020-04-24',90,'Glavobolja');

INSERT INTO `CUVAR_OBAVJEST` VALUES 
(47234,10010,'2021-04-20','zdrava'),
(47234,10010,'2021-04-23','bolesna'),
(47234,10010,'2021-04-24','zdrava'),
(47234,10010,'2021-04-24','bolesna'),
(107777487,10010,'2021-04-11','bolesna'),
(107777487,10010,'2021-04-16','zdrava'),
(107777487,10010,'2021-04-17','bolesna'),
(107777487,10010,'2021-04-20','zdrava'),
(107777487,10010,'2021-04-23','bolesna'),
(155344501,10010,'2021-04-16','bolesna'),
(155344501,10010,'2021-04-20','gravidna'),
(155344501,10010,'2021-04-23','bolesna'),
(155344501,10010,'2021-04-24','zdrava'),
(155344501,10010,'2021-04-24','gravidna'),
(678157324,10010,'2021-04-23','zdrava'),
(107777487,10011,'2021-04-11','bolesna'),
(551854014,10011,'2021-04-20','zdrava'),
(551854014,10011,'2021-04-20','gravidna'),
(551854014,10011,'2021-04-23','zdrava'),
(107777487,10012,'2021-04-11','bolesna'),
(47234,10014,'2021-04-23','zdrava'),
(47234,10014,'2021-04-23','bolesna'),
(47234,10014,'2021-04-24','zdrava'),
(47234,10014,'2021-04-24','bolesna');

INSERT INTO `BRINE_SE_O` VALUES 
(10010,47234),
(10014,47234),
(10014,155344501),
(10010,107777487),
(10010,155344501),
(10012,222252359),
(10011,551854014),
(10010,678157324);

INSERT INTO `ZOO_ZALIHE_OBAVJESTI` VALUES 
(1,10010,'2021-04-22'),
(1,10010,'2021-04-24'),
(1257629409,10010,'2021-04-11'),
(1257629409,10010,'2021-04-16'),
(1106475763,10010,'2021-04-16'),
(100001,10008,'2021-04-22'),
(100004,10008,'2021-04-22');

INSERT INTO `narudzba` VALUES 
(20896794,1000002,'2021-07-19 00:00:00',75.11,4,'mm4@yahoo.com','NA','dostavljeno','19 Brankova Ulica','Banja Luka','BA',78000),
(21474836,1000002,'2021-04-06 02:09:08',39.98,2,'ds17@outlook.com','NA','poslato','17 Brankova Ulica','Banja Luka','BA',78000),
(214748365,1000002,'2021-04-06 02:11:07',39.98,2,'ds17@outlook.com','NA','poslato','17 Brankova Ulica','Banja Luka','BA',78000);



