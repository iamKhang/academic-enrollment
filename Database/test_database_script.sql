select * from [dbo].[departments];

select * from [dbo].[concurrent_courses];
select * from [dbo].[curriculums]

SELECT TABLE_SCHEMA, TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_SCHEMA, TABLE_NAME;

select * from [dbo].[subject_curriculum_elective_groups]