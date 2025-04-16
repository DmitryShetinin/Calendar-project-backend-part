CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;
CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TABLE calendars (
    calendarid uuid NOT NULL DEFAULT (gen_random_uuid()),
    name character varying(50) NOT NULL,
    userid uuid,
    CONSTRAINT calendars_pkey PRIMARY KEY (calendarid)
);

CREATE TABLE events (
    event1 uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Userid" uuid,
    calendarid uuid,
    "Name" text NOT NULL,
    "Discriotion" text NOT NULL,
    "Allday" boolean,
    "Startdate" text NOT NULL,
    "Enddate" text NOT NULL,
    "Participants" text[] NOT NULL,
    "Reminder" text NOT NULL,
    CONSTRAINT events_pkey PRIMARY KEY (event1)
);

CREATE TABLE users (
    id uuid NOT NULL DEFAULT (gen_random_uuid()),
    "Username" text NOT NULL,
    "Passwordhash" text NOT NULL,
    "Email" text NOT NULL,
    CONSTRAINT users_pkey PRIMARY KEY (id)
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20250412054447_InitialCreate', '9.0.4');

COMMIT;

