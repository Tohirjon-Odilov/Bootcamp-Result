-- task 1
SELECT CU.TITLE,
	(SELECT TITLE
		FROM COURSE
		WHERE COURSE_ID = PR.PREREQ_ID)
FROM COURSE AS CU
JOIN PREREQ AS PR ON CU.COURSE_ID = PR.COURSE_ID

-- task 2
-- select * from prereq
-- inner join course using(course_id); --ikkalasi teng = on course.course_id = prereq.course_id

SELECT C.title as "course_name",
	I.NAME AS "professor",
	YEAR,
	SEMESTER,
	BUILDING,
	ROOM_NUMBER
FROM SECTION S
INNER JOIN COURSE C USING(COURSE_ID)
INNER JOIN TEACHES USING(COURSE_ID, SEC_ID, SEMESTER, YEAR)
INNER JOIN INSTRUCTOR I USING(ID)

-- select * from section
-- inner join teaches using(course_id, sec_id, year, semester)
-- inner join instructor using(id)

-- TASK 3

SELECT I.name, count(*) as students
FROM STUDENT AS ST
INNER JOIN TAKES AS TK ON TK.ID = ST.ID
INNER JOIN TEACHES AS TCH ON TK.COURSE_ID = TCH.COURSE_ID
AND TK.SEC_ID = TCH.SEC_ID
AND TK.YEAR = TCH.YEAR
AND TK.SEMESTER = TCH.SEMESTER
INNER JOIN INSTRUCTOR AS I ON TCH.ID = I.ID
GROUP BY I.id;


