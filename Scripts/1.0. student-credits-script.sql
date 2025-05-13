CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM pg_namespace WHERE nspname = 'dbo') THEN
        CREATE SCHEMA dbo;
    END IF;
END $EF$;

CREATE TABLE dbo."Student" (
    "StudentId" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "DocumentNumber" text NOT NULL,
    "Firstname" character varying(50) NOT NULL,
    "Lastname" character varying(50) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Created" timestamp with time zone NOT NULL DEFAULT (now()),
    CONSTRAINT "PK_Student" PRIMARY KEY ("StudentId")
);

CREATE TABLE dbo."Subject" (
    "SubjectId" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Name" character varying(100) NOT NULL,
    "Description" text,
    "Created" timestamp with time zone NOT NULL DEFAULT (now()),
    CONSTRAINT "PK_Subject" PRIMARY KEY ("SubjectId")
);

CREATE TABLE dbo."Teacher" (
    "TeacherId" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "DocumentNumber" text NOT NULL,
    "Firstname" character varying(50) NOT NULL,
    "Lastname" character varying(50) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Profession" character varying(30) NOT NULL,
    "Created" timestamp with time zone NOT NULL DEFAULT (now()),
    CONSTRAINT "PK_Teacher" PRIMARY KEY ("TeacherId")
);

CREATE TABLE dbo."TeacherDetail" (
    "TeacherDetailId" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "TeacherId" uuid NOT NULL,
    "SubjectId" uuid NOT NULL,
    "Credits" numeric(2,1) NOT NULL,
    "Created" timestamp with time zone NOT NULL DEFAULT (now()),
    CONSTRAINT "PK_TeacherDetail" PRIMARY KEY ("TeacherDetailId"),
    CONSTRAINT "FK_TeacherDetail_Subject_SubjectId" FOREIGN KEY ("SubjectId") REFERENCES dbo."Subject" ("SubjectId") ON DELETE CASCADE,
    CONSTRAINT "FK_TeacherDetail_Teacher_TeacherId" FOREIGN KEY ("TeacherId") REFERENCES dbo."Teacher" ("TeacherId") ON DELETE CASCADE
);

CREATE TABLE dbo."StudentDetail" (
    "StudentDetailId" uuid NOT NULL DEFAULT (gen_random_uuid()),
    "TeacherDetailId" uuid NOT NULL,
    "StudentId" uuid NOT NULL,
    "Created" timestamp with time zone NOT NULL DEFAULT (now()),
    CONSTRAINT "PK_StudentDetail" PRIMARY KEY ("StudentDetailId"),
    CONSTRAINT "FK_StudentDetail_Student_StudentId" FOREIGN KEY ("StudentId") REFERENCES dbo."Student" ("StudentId") ON DELETE CASCADE,
    CONSTRAINT "FK_StudentDetail_TeacherDetail_TeacherDetailId" FOREIGN KEY ("TeacherDetailId") REFERENCES dbo."TeacherDetail" ("TeacherDetailId") ON DELETE CASCADE
);

INSERT INTO dbo."Student" ("StudentId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname")
VALUES ('107e7e52-74fc-4589-b7d9-5f1ffc434637', TIMESTAMPTZ '2024-03-03T02:02:02+00:00', '1109432112', 'jeison.bonilla@gmail.com', 'Jeison Andrés', 'Bonilla');
INSERT INTO dbo."Student" ("StudentId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname")
VALUES ('ee466b07-1d3e-4356-8d03-0067d5ba30e5', TIMESTAMPTZ '2024-03-01T00:01:01+00:00', '1033671288', 'angela.suarez@outlook.com', 'Angela Natalia', 'Suarez');

INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('2ee9ebee-460c-4389-a50b-f0b602a2f617', TIMESTAMPTZ '2024-01-11T01:00:01+00:00', 'Learn to identify system problems with a general, reusable, scalable and applicable solution', 'Design Patterns');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('4b2d9626-0259-42a5-a98c-11019b4cf873', TIMESTAMPTZ '2024-01-20T07:06:07+00:00', 'Discover how a Scrum Master can lead a team and keep members focused on the principles of the framework', 'Scrum Master Fundamentals');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('5a5f617c-4b9b-4974-9104-bd173b107172', TIMESTAMPTZ '2024-01-16T03:02:03+00:00', 'Learn how clean architectures work to separate concerns into different, well-defined layers, with strict rules about how they should interact with each other', 'Clean Architecture');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('8a4b2308-49d0-44db-b2d5-675742d5f2fe', TIMESTAMPTZ '2024-01-15T02:01:02+00:00', 'Learn how to apply a set of rules and best practices for software development', 'S.O.L.I.D Principles');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('9748e5ff-07ba-4cb8-8617-53a785fc2ebf', TIMESTAMPTZ '2024-01-22T09:08:09+00:00', 'Learn how to become an expert with TypeScript the JavaScript superset for strict typing', 'Development With TypeScript');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('a3e42c74-8a68-4e2d-b339-caa2e89db0a7', TIMESTAMPTZ '2024-01-23T10:09:10+00:00', 'Learn how to develop with one of the most popular and powerful frameworks, create robust applications', 'Angular Fundamentals');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('e2fd4b74-7b10-446e-821e-55717899c400', TIMESTAMPTZ '2024-01-19T06:05:06+00:00', 'Learn about the most popular tools for QA Automation, features and benefits', 'QA Automation Tools');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('e9a4cce8-57b0-4693-bf22-cfec292bccc5', TIMESTAMPTZ '2024-01-18T05:04:05+00:00', 'Learn why QA Automation is so important in the software development cycle', 'QA Automation Fundamentals');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('eb8e2deb-9f48-4376-b5d0-9e5f898d6586', TIMESTAMPTZ '2024-01-17T04:03:04+00:00', 'Learn how to implement a design methodology for rapid deployment and updating of cloud-based applications', 'Microservices Architecture');
INSERT INTO dbo."Subject" ("SubjectId", "Created", "Description", "Name")
VALUES ('fc560c08-aa92-44c6-9ae1-101987824877', TIMESTAMPTZ '2024-01-21T08:07:08+00:00', 'Discover how a Scrum Master should expertly plan to maintain a fully agile team', 'Planning a scrum master');

INSERT INTO dbo."Teacher" ("TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession")
VALUES ('08cd0782-93ba-4de3-b363-e7a4df2bfe7b', TIMESTAMPTZ '2024-02-03T02:03:03+00:00', '1127789231', 'ana.suarez@outlook.com', 'Ana Camila', 'Suarez', 'QA Automation');
INSERT INTO dbo."Teacher" ("TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession")
VALUES ('42318f73-c7fd-4490-9594-7c72a77bbee7', TIMESTAMPTZ '2024-02-04T03:04:04+00:00', '1643398122', 'maria_natalia.garcia@outlook.com', 'Maria Natalia', 'Garcia', 'Scrum Master');
INSERT INTO dbo."Teacher" ("TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession")
VALUES ('c774f591-750a-47f9-b283-327cdb62f627', TIMESTAMPTZ '2024-02-05T04:05:05+00:00', '1992233120', 'carlos.herrera@gmail.com', 'Carlos Francisco', 'Herrera', 'Senior Frontend Developer');
INSERT INTO dbo."Teacher" ("TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession")
VALUES ('d3e5862d-3c30-4b35-8a0d-4632572aae47', TIMESTAMPTZ '2024-02-01T00:01:01+00:00', '1023944678', 'cristian10camilo95@gmail.com', 'Cristian Camilo', 'Bonilla', 'Senior Software Developer');
INSERT INTO dbo."Teacher" ("TeacherId", "Created", "DocumentNumber", "Email", "Firstname", "Lastname", "Profession")
VALUES ('f41ed5f9-d853-4077-b6fe-9bb277bee93d', TIMESTAMPTZ '2024-02-02T01:02:02+00:00', '1090012334', 'fernando.gutierrez@gmail.com', 'Fernando', 'Gutierrez', 'Senior Software Architect');

INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('10ed0335-ece3-4e80-9c01-28e1f1f3fe67', TIMESTAMPTZ '2024-02-11T11:10:10+00:00', 3.0, 'a3e42c74-8a68-4e2d-b339-caa2e89db0a7', 'c774f591-750a-47f9-b283-327cdb62f627');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('3b34bdd2-dc7c-41a1-bd79-dc8465aa2bf1', TIMESTAMPTZ '2024-02-05T04:03:04+00:00', 3.0, 'eb8e2deb-9f48-4376-b5d0-9e5f898d6586', 'f41ed5f9-d853-4077-b6fe-9bb277bee93d');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('4f098579-1bd2-4e7c-822a-9160871450de', TIMESTAMPTZ '2024-02-08T07:06:07+00:00', 3.0, '4b2d9626-0259-42a5-a98c-11019b4cf873', '42318f73-c7fd-4490-9594-7c72a77bbee7');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('7240162d-4f52-425d-a4f6-54b4127e8828', TIMESTAMPTZ '2024-02-10T09:08:09+00:00', 3.0, '9748e5ff-07ba-4cb8-8617-53a785fc2ebf', 'c774f591-750a-47f9-b283-327cdb62f627');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('a5794476-1317-4ebc-86b3-e9640b20a1a8', TIMESTAMPTZ '2024-02-09T08:07:08+00:00', 3.0, 'fc560c08-aa92-44c6-9ae1-101987824877', '42318f73-c7fd-4490-9594-7c72a77bbee7');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('ccc8bb25-685f-404b-b53d-d446686f9cec', TIMESTAMPTZ '2024-02-07T06:05:06+00:00', 3.0, 'e2fd4b74-7b10-446e-821e-55717899c400', '08cd0782-93ba-4de3-b363-e7a4df2bfe7b');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('cf98b2d3-7d9b-4ce1-996a-ed25c706b644', TIMESTAMPTZ '2024-02-06T05:04:05+00:00', 3.0, 'e9a4cce8-57b0-4693-bf22-cfec292bccc5', '08cd0782-93ba-4de3-b363-e7a4df2bfe7b');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('d6e0c50c-e994-4d6b-aca0-ebc09b411aa0', TIMESTAMPTZ '2024-02-04T03:02:03+00:00', 3.0, '5a5f617c-4b9b-4974-9104-bd173b107172', 'f41ed5f9-d853-4077-b6fe-9bb277bee93d');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('f79f1e3c-8974-4b38-8f9d-72e738efb046', TIMESTAMPTZ '2024-02-03T02:01:02+00:00', 3.0, '8a4b2308-49d0-44db-b2d5-675742d5f2fe', 'd3e5862d-3c30-4b35-8a0d-4632572aae47');
INSERT INTO dbo."TeacherDetail" ("TeacherDetailId", "Created", "Credits", "SubjectId", "TeacherId")
VALUES ('f87b9e01-7066-4a18-bbe5-560a9c6ddec2', TIMESTAMPTZ '2024-02-02T01:00:01+00:00', 3.0, '2ee9ebee-460c-4389-a50b-f0b602a2f617', 'd3e5862d-3c30-4b35-8a0d-4632572aae47');

INSERT INTO dbo."StudentDetail" ("StudentDetailId", "Created", "StudentId", "TeacherDetailId")
VALUES ('11ab0e13-3a0a-4fd7-9f80-3dc89b181efb', TIMESTAMPTZ '2024-03-02T01:00:01+00:00', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2');
INSERT INTO dbo."StudentDetail" ("StudentDetailId", "Created", "StudentId", "TeacherDetailId")
VALUES ('2096ecba-29db-49d6-9646-a6c3e424953f', TIMESTAMPTZ '2024-03-03T02:01:02+00:00', 'ee466b07-1d3e-4356-8d03-0067d5ba30e5', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
INSERT INTO dbo."StudentDetail" ("StudentDetailId", "Created", "StudentId", "TeacherDetailId")
VALUES ('90812e38-67ad-4207-8017-e2b09231231e', TIMESTAMPTZ '2024-03-02T01:00:04+00:00', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f79f1e3c-8974-4b38-8f9d-72e738efb046');
INSERT INTO dbo."StudentDetail" ("StudentDetailId", "Created", "StudentId", "TeacherDetailId")
VALUES ('eab71419-9084-4e72-9558-ce4d76f0fd30', TIMESTAMPTZ '2024-03-04T03:02:03+00:00', '107e7e52-74fc-4589-b7d9-5f1ffc434637', 'f87b9e01-7066-4a18-bbe5-560a9c6ddec2');

CREATE UNIQUE INDEX "IX_Student_DocumentNumber_Email" ON dbo."Student" ("DocumentNumber", "Email");

CREATE INDEX "IX_StudentDetail_StudentId" ON dbo."StudentDetail" ("StudentId");

CREATE INDEX "IX_StudentDetail_TeacherDetailId" ON dbo."StudentDetail" ("TeacherDetailId");

CREATE UNIQUE INDEX "IX_Subject_Name" ON dbo."Subject" ("Name");

CREATE UNIQUE INDEX "IX_Teacher_DocumentNumber_Email" ON dbo."Teacher" ("DocumentNumber", "Email");

CREATE INDEX "IX_TeacherDetail_SubjectId" ON dbo."TeacherDetail" ("SubjectId");

CREATE INDEX "IX_TeacherDetail_TeacherId" ON dbo."TeacherDetail" ("TeacherId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250513051704_InitialCreate', '8.0.15');

COMMIT;
