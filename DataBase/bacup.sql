--
-- PostgreSQL database dump
--

-- Dumped from database version 9.6.3
-- Dumped by pg_dump version 9.6.3

-- Started on 2017-08-03 22:43:21

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SET check_function_bodies = false;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 1 (class 3079 OID 12387)
-- Name: plpgsql; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS plpgsql WITH SCHEMA pg_catalog;


--
-- TOC entry 2191 (class 0 OID 0)
-- Dependencies: 1
-- Name: EXTENSION plpgsql; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION plpgsql IS 'PL/pgSQL procedural language';


--
-- TOC entry 2 (class 3079 OID 17428)
-- Name: uuid-ossp; Type: EXTENSION; Schema: -; Owner: 
--

CREATE EXTENSION IF NOT EXISTS "uuid-ossp" WITH SCHEMA public;


--
-- TOC entry 2192 (class 0 OID 0)
-- Dependencies: 2
-- Name: EXTENSION "uuid-ossp"; Type: COMMENT; Schema: -; Owner: 
--

COMMENT ON EXTENSION "uuid-ossp" IS 'generate universally unique identifiers (UUIDs)';


SET search_path = public, pg_catalog;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 186 (class 1259 OID 17439)
-- Name: Menus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Menus" (
    "Id" uuid NOT NULL,
    "Code" text,
    "Icon" text,
    "Name" text,
    "ParentId" uuid NOT NULL,
    "Remarks" text,
    "SerialNumber" integer NOT NULL,
    "Type" integer NOT NULL,
    "Url" text
);


ALTER TABLE "Menus" OWNER TO postgres;

--
-- TOC entry 187 (class 1259 OID 17447)
-- Name: Projects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Projects" (
    "Id" uuid NOT NULL,
    "AgentFees" numeric NOT NULL,
    "AgentOrganization" text,
    "BidPrice" numeric NOT NULL,
    "BidSecurityFees" numeric NOT NULL,
    "BidSecurityReceiveAccount" text,
    "BidSecurityReturnTime" text,
    "BidTime" timestamp without time zone,
    "BidType" text,
    "Code" text,
    "Competitor" text,
    "ConstructionSubcontractor" text,
    "CreateTime" timestamp without time zone,
    "DevelopmentOrganization" text,
    "Name" text,
    "Refund" numeric NOT NULL,
    "Remark" text,
    "Status" integer NOT NULL,
    "UnionOrganization" text,
    "UpdateTime" timestamp without time zone
);


ALTER TABLE "Projects" OWNER TO postgres;

--
-- TOC entry 190 (class 1259 OID 17471)
-- Name: RoleMenus; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "RoleMenus" (
    "RoleId" uuid NOT NULL,
    "MenuId" uuid NOT NULL
);


ALTER TABLE "RoleMenus" OWNER TO postgres;

--
-- TOC entry 188 (class 1259 OID 17455)
-- Name: Roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Roles" (
    "Id" uuid NOT NULL,
    "CreateTime" timestamp without time zone,
    "CreateUserId" uuid NOT NULL,
    "Name" text,
    "Remarks" text
);


ALTER TABLE "Roles" OWNER TO postgres;

--
-- TOC entry 191 (class 1259 OID 17486)
-- Name: UserProjects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "UserProjects" (
    "UserId" uuid NOT NULL,
    "ProjectId" uuid NOT NULL,
    "Responsibility" integer NOT NULL
);


ALTER TABLE "UserProjects" OWNER TO postgres;

--
-- TOC entry 192 (class 1259 OID 17501)
-- Name: UserRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "UserRoles" (
    "UserId" uuid NOT NULL,
    "RoleId" uuid NOT NULL
);


ALTER TABLE "UserRoles" OWNER TO postgres;

--
-- TOC entry 189 (class 1259 OID 17463)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE "Users" (
    "Id" uuid NOT NULL,
    "CreateTime" timestamp without time zone,
    "CreateUserId" uuid NOT NULL,
    "EMail" text,
    "IsDeleted" integer NOT NULL,
    "IsSupervisor" boolean NOT NULL,
    "LastLoginTime" timestamp without time zone NOT NULL,
    "LoginTimes" integer NOT NULL,
    "MobileNumber" text,
    "Name" text,
    "Password" text NOT NULL,
    "Remarks" text,
    "UserName" text NOT NULL
);


ALTER TABLE "Users" OWNER TO postgres;

--
-- TOC entry 2178 (class 0 OID 17439)
-- Dependencies: 186
-- Data for Name: Menus; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Menus" ("Id", "Code", "Icon", "Name", "ParentId", "Remarks", "SerialNumber", "Type", "Url") FROM stdin;
\.


--
-- TOC entry 2179 (class 0 OID 17447)
-- Dependencies: 187
-- Data for Name: Projects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Projects" ("Id", "AgentFees", "AgentOrganization", "BidPrice", "BidSecurityFees", "BidSecurityReceiveAccount", "BidSecurityReturnTime", "BidTime", "BidType", "Code", "Competitor", "ConstructionSubcontractor", "CreateTime", "DevelopmentOrganization", "Name", "Refund", "Remark", "Status", "UnionOrganization", "UpdateTime") FROM stdin;
13066a3d-f748-4d97-9723-e505e4ee59a0	0	测试代理公司1	0	0	\N	\N	2017-08-03 22:29:04.136445	工程总承包	001	\N	\N	\N	测试招标公司1	测试项目1	0	\N	0	\N	\N
c875dba1-6366-4aaf-9ab8-b14970352fb6	0	测试代理公司2	0	0	\N	\N	2017-08-03 22:29:04.152456	工程总承包	002	\N	\N	\N	测试招标公司2	测试项目2	0	\N	0	\N	\N
97c6817f-75b3-47e8-b8b0-02c75fc85307	0	测试代理公司3	0	0	\N	\N	2017-08-03 22:29:04.152456	工程总承包	003	\N	\N	\N	测试招标公司3	测试项目3	0	\N	0	\N	\N
5e28e15d-0a8d-4ce9-9446-44c81ea6c7b3	0	测试代理公司3	0	0	\N	\N	2017-08-03 22:29:04.152456	设计	004	\N	\N	\N	测试招标公司2	测试项目4	0	\N	0	\N	\N
2468c8cc-5bfc-42e4-a1ad-c0a982146ab0	0	测试代理公司3	0	0	\N	\N	2017-08-03 22:29:04.152456	物资	005	\N	\N	\N	测试招标公司2	测试项目5	0	\N	0	\N	\N
\.


--
-- TOC entry 2182 (class 0 OID 17471)
-- Dependencies: 190
-- Data for Name: RoleMenus; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "RoleMenus" ("RoleId", "MenuId") FROM stdin;
\.


--
-- TOC entry 2180 (class 0 OID 17455)
-- Dependencies: 188
-- Data for Name: Roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Roles" ("Id", "CreateTime", "CreateUserId", "Name", "Remarks") FROM stdin;
6bb28aa4-a1df-415d-b63d-eb24f359314c	\N	00000000-0000-0000-0000-000000000000	项目管理员	\N
6c50780d-5960-4a42-9ba7-63cc2cea16f8	\N	00000000-0000-0000-0000-000000000000	普通人员	\N
\.


--
-- TOC entry 2183 (class 0 OID 17486)
-- Dependencies: 191
-- Data for Name: UserProjects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "UserProjects" ("UserId", "ProjectId", "Responsibility") FROM stdin;
330d4267-e364-4b54-963f-e0e43cbba343	13066a3d-f748-4d97-9723-e505e4ee59a0	1
330d4267-e364-4b54-963f-e0e43cbba343	2468c8cc-5bfc-42e4-a1ad-c0a982146ab0	2
79e6f138-1b59-472c-b15f-d97b0ee19f9d	5e28e15d-0a8d-4ce9-9446-44c81ea6c7b3	1
79e6f138-1b59-472c-b15f-d97b0ee19f9d	97c6817f-75b3-47e8-b8b0-02c75fc85307	2
79e6f138-1b59-472c-b15f-d97b0ee19f9d	c875dba1-6366-4aaf-9ab8-b14970352fb6	3
\.


--
-- TOC entry 2184 (class 0 OID 17501)
-- Dependencies: 192
-- Data for Name: UserRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "UserRoles" ("UserId", "RoleId") FROM stdin;
330d4267-e364-4b54-963f-e0e43cbba343	6bb28aa4-a1df-415d-b63d-eb24f359314c
79e6f138-1b59-472c-b15f-d97b0ee19f9d	6c50780d-5960-4a42-9ba7-63cc2cea16f8
\.


--
-- TOC entry 2181 (class 0 OID 17463)
-- Dependencies: 189
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY "Users" ("Id", "CreateTime", "CreateUserId", "EMail", "IsDeleted", "IsSupervisor", "LastLoginTime", "LoginTimes", "MobileNumber", "Name", "Password", "Remarks", "UserName") FROM stdin;
1e84f7ea-e8b0-4918-a5d0-db78e9bb2672	\N	00000000-0000-0000-0000-000000000000	\N	0	t	0001-01-01 00:00:00	0	\N	超级管理员	123456	\N	admin
330d4267-e364-4b54-963f-e0e43cbba343	\N	00000000-0000-0000-0000-000000000000	\N	0	f	0001-01-01 00:00:00	0	\N	测试管理员	123456	\N	lqy
79e6f138-1b59-472c-b15f-d97b0ee19f9d	\N	00000000-0000-0000-0000-000000000000	\N	0	f	0001-01-01 00:00:00	0	\N	测试1	123456	\N	www
\.


--
-- TOC entry 2039 (class 2606 OID 17446)
-- Name: Menus PK_Menus; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Menus"
    ADD CONSTRAINT "PK_Menus" PRIMARY KEY ("Id");


--
-- TOC entry 2041 (class 2606 OID 17454)
-- Name: Projects PK_Projects; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Projects"
    ADD CONSTRAINT "PK_Projects" PRIMARY KEY ("Id");


--
-- TOC entry 2048 (class 2606 OID 17475)
-- Name: RoleMenus PK_RoleMenus; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "RoleMenus"
    ADD CONSTRAINT "PK_RoleMenus" PRIMARY KEY ("RoleId", "MenuId");


--
-- TOC entry 2043 (class 2606 OID 17462)
-- Name: Roles PK_Roles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Roles"
    ADD CONSTRAINT "PK_Roles" PRIMARY KEY ("Id");


--
-- TOC entry 2051 (class 2606 OID 17490)
-- Name: UserProjects PK_UserProjects; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserProjects"
    ADD CONSTRAINT "PK_UserProjects" PRIMARY KEY ("UserId", "ProjectId", "Responsibility");


--
-- TOC entry 2054 (class 2606 OID 17505)
-- Name: UserRoles PK_UserRoles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserRoles"
    ADD CONSTRAINT "PK_UserRoles" PRIMARY KEY ("UserId", "RoleId");


--
-- TOC entry 2045 (class 2606 OID 17470)
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- TOC entry 2046 (class 1259 OID 17516)
-- Name: IX_RoleMenus_MenuId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_RoleMenus_MenuId" ON "RoleMenus" USING btree ("MenuId");


--
-- TOC entry 2049 (class 1259 OID 17517)
-- Name: IX_UserProjects_ProjectId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserProjects_ProjectId" ON "UserProjects" USING btree ("ProjectId");


--
-- TOC entry 2052 (class 1259 OID 17518)
-- Name: IX_UserRoles_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserRoles_RoleId" ON "UserRoles" USING btree ("RoleId");


--
-- TOC entry 2055 (class 2606 OID 17476)
-- Name: RoleMenus FK_RoleMenus_Menus_MenuId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "RoleMenus"
    ADD CONSTRAINT "FK_RoleMenus_Menus_MenuId" FOREIGN KEY ("MenuId") REFERENCES "Menus"("Id") ON DELETE CASCADE;


--
-- TOC entry 2056 (class 2606 OID 17481)
-- Name: RoleMenus FK_RoleMenus_Roles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "RoleMenus"
    ADD CONSTRAINT "FK_RoleMenus_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Roles"("Id") ON DELETE CASCADE;


--
-- TOC entry 2057 (class 2606 OID 17491)
-- Name: UserProjects FK_UserProjects_Projects_ProjectId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserProjects"
    ADD CONSTRAINT "FK_UserProjects_Projects_ProjectId" FOREIGN KEY ("ProjectId") REFERENCES "Projects"("Id") ON DELETE CASCADE;


--
-- TOC entry 2058 (class 2606 OID 17496)
-- Name: UserProjects FK_UserProjects_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserProjects"
    ADD CONSTRAINT "FK_UserProjects_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users"("Id") ON DELETE CASCADE;


--
-- TOC entry 2059 (class 2606 OID 17506)
-- Name: UserRoles FK_UserRoles_Roles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserRoles"
    ADD CONSTRAINT "FK_UserRoles_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "Roles"("Id") ON DELETE CASCADE;


--
-- TOC entry 2060 (class 2606 OID 17511)
-- Name: UserRoles FK_UserRoles_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY "UserRoles"
    ADD CONSTRAINT "FK_UserRoles_Users_UserId" FOREIGN KEY ("UserId") REFERENCES "Users"("Id") ON DELETE CASCADE;


-- Completed on 2017-08-03 22:43:22

--
-- PostgreSQL database dump complete
--

