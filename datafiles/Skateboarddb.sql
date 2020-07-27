DROP TABLE IF EXISTS "users" CASCADE;
DROP TABLE IF EXISTS "skateboards" CASCADE;
/*DROP TABLE IF EXISTS "griptape" CASCADE;*/
DROP TABLE IF EXISTS "deck" CASCADE;
DROP TABLE IF EXISTS "wheels" CASCADE;
DROP TABLE IF EXISTS "trucks" CASCADE;
/*DROP TABLE IF EXISTS "bearings" CASCADE;*/
DROP TABLE IF EXISTS "liked" CASCADE;
DROP TRIGGER IF EXISTS check_number_of_boards ON skateboards CASCADE;
DROP FUNCTION IF EXISTS check_number_of_boards;

CREATE TABLE users(
    user_id SERIAL Primary Key,
	user_email VARCHAR(30) UNIQUE,
    nickname VARCHAR(20),
    pw TEXT
);

CREATE TABLE deck(
	deck_id SERIAL Primary Key,
	deck_brand VARCHAR(30),
	deck_width float ,
	deck_length float
);

CREATE TABLE wheels(
	wheels_id SERIAL Primary Key,
	wheels_brand VARCHAR(30),
	wheels_size int,
	wheels_hardness VARCHAR(10)
);

CREATE TABLE trucks(
	trucks_id SERIAL Primary Key,
	trucks_brand VARCHAR(30),
	trucks_size float
);

CREATE TABLE skateboards(
	skateboard_id SERIAL Primary Key,
    user_id INT REFERENCES users(user_id),
	deck_id INT REFERENCES deck(deck_id),
	wheels_id INT REFERENCES wheels(wheels_id),
	trucks_id INT REFERENCES trucks(trucks_id)
);

CREATE TABLE liked(
	user_id INT REFERENCES users(user_id),
	skateboard_id INT REFERENCES skateboards(skateboard_id),
	UNIQUE(user_id,skateboard_id)
);

/*COPY griptape(griptape_brand)
FROM 'C:\WebPA\SkateboardCollectorNet\datafiles\Griptapes.csv' 
DELIMITER ',';*/

COPY deck(deck_brand,deck_width,deck_length)
FROM 'C:\WebPA\SkateboardCollectorNet\datafiles\Decks.csv'
DELIMITER ',';

COPY wheels(wheels_brand,wheels_size,wheels_hardness)
FROM 'C:\WebPA\SkateboardCollectorNet\datafiles\Wheels.csv'
DELIMITER ',';

COPY trucks(trucks_brand,trucks_size)
FROM 'C:\WebPA\SkateboardCollectorNet\datafiles\Trucks.csv'
DELIMITER ',';

INSERT INTO deck(deck_id,deck_brand,deck_width,deck_length)
VALUES(0,'placeholder','0','0');

INSERT INTO wheels(wheels_id,wheels_brand,wheels_size,wheels_hardness)
VALUES(0,'placeholder',0,'empty');

INSERT INTO trucks(trucks_id,trucks_brand,trucks_size)
VALUES(0,'placeholder',0);
/*COPY bearings(bearings_brand,bearings_type)
FROM 'C:\WebPA\SkateboardCollectorNet\datafiles\Bearings.csv'
DELIMITER ',';*/

INSERT INTO users(user_email,nickname,pw)
VALUES ('gayparade@gmail.com', 'izmosferfitestek', 'GIMMEDICK');
INSERT INTO users(user_email,nickname,pw)
VALUES ('sanyika@citromail.hu', 'foreversimpin', 'lovepoki69');
INSERT INTO users(user_email,nickname,pw)
VALUES ('joggerfan@gmail.com', 'finnajogg420', 'dinndunuffin110');

INSERT INTO skateboards(user_id,deck_id,wheels_id,trucks_id)
VALUES(1,1,1,2);
INSERT INTO skateboards(user_id,deck_id,wheels_id,trucks_id)
VALUES(1,1,2,2);
INSERT INTO skateboards(user_id,deck_id,wheels_id,trucks_id)
VALUES(1,0,0,0);

INSERT INTO liked(user_id,skateboard_id)
VALUES(2,1);
INSERT INTO liked(user_id,skateboard_id)
VALUES(1,1);

SELECT * FROM skateboards WHERE user_id = 1;

CREATE FUNCTION check_number_of_boards() returns trigger as $check_number_of_boards$
Begin
    IF (SELECT COUNT(*) FROM skateboards WHERE user_id = new.user_id) = 3
    THEN
    raise 'You cant add more skateboard slots!';
    end if;
    RETURN new ;
End;
$check_number_of_boards$ LANGUAGE plpgsql;

CREATE TRIGGER check_number_of_boards
BEFORE INSERT ON skateboards
FOR EACH ROW 
EXECUTE PROCEDURE check_number_of_boards();



