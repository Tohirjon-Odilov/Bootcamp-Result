CREATE TABLE Animals(
    id bigserial NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Age BIGINT NOT NULL,
    Breed VARCHAR(255) NOT NULL,
    Status VARCHAR(255) NOT NULL
);
ALTER TABLE
    Animals ADD PRIMARY KEY(id);
CREATE TABLE Potential_Adopters(
    id bigserial NOT NULL,
    Name VARCHAR(255) NOT NULL,
    Contact BIGINT NOT NULL,
    Home_en VARCHAR(255) NOT NULL
);
ALTER TABLE
    Potential_Adopters ADD PRIMARY KEY(id);
CREATE TABLE Medical_Records(
    id BIGINT NOT NULL,
    Vac_status VARCHAR(255) NOT NULL,
    Last_v_Date DATE NOT NULL,
    Med_con VARCHAR(255) NOT NULL,
    Pet_id BIGINT NOT NULL
);
ALTER TABLE
    Medical_Records ADD PRIMARY KEY(id);
CREATE TABLE Adoption_Transactions(
    id bigserial NOT NULL,
    Date_Adop DATE NOT NULL,
    Adop_pet BIGINT NOT NULL,
    Adopter BIGINT NOT NULL,
    Status VARCHAR(255) NOT NULL
);
ALTER TABLE
    Adoption_Transactions ADD PRIMARY KEY(id);
ALTER TABLE
    Adoption_Transactions ADD CONSTRAINT "adoption_transactions_adop_pet_unique" UNIQUE(Adop_pet);
ALTER TABLE
    Medical_Records ADD CONSTRAINT "medical_records_pet_id_foreign" FOREIGN KEY("Pet_id") REFERENCES Animals(id);
ALTER TABLE
    Adoption_Transactions ADD CONSTRAINT "adoption_transactions_adop_pet_foreign" FOREIGN KEY(Adop_pet) REFERENCES Animals(id);
ALTER TABLE
    Adoption_Transactions ADD CONSTRAINT "adoption_transactions_adopter_foreign" FOREIGN KEY(Adopter) REFERENCES Potential_Adopters(id);



-- 1 func
create or replace procedure avg_age_by_breed(breed_i Varchar)
language plpgsql
AS $$
BEGIN
  raise notice select avg(Age) from Animals where Breed = breed_i ;
END
$$;


-- 2 func
create or replace procedure pets_count_of_adopter(adopter_id int)
language plpgsql
AS $$
BEGIN
  raise notice select count(*) from Aboption_Transactions where where adopter = adopter_id;
END
$$;


-- 3 func
CREATE OR REPLACE FUNCTION generate_medical_records_of_pet(med_id bigint)
RETURNS TABLE (vac_status varchar,Last_v_Date date,med_con varchar,pet_id bigint)
LANGUAGE plpgsql
AS $$
BEGIN
    RETURN QUERY SELECT m.vac_status,m.Last_v_Date,m.med_con,m.pet_id  FROM Medical_Records as m WHERE m.pet_id = med_id;
END;
$$;

SELECT * FROM generate_medical_records_of_pet(1);


--This home task create by 
--Tohirjon Odilov, 
--Muhammadabdulloh Ummataliev,
--Asadulloh Tojiev,
--Akramjon Abduvahobov,
--Hayotilla Tursunboyev
