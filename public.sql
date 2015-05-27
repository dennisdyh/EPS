/*
Navicat PGSQL Data Transfer

Source Server         : epsremote
Source Server Version : 90306
Source Host           : 192.168.187.133:5432
Source Database       : EPS
Source Schema         : public

Target Server Type    : PGSQL
Target Server Version : 90306
File Encoding         : 65001

Date: 2015-05-27 15:25:01
*/


-- ----------------------------
-- Sequence structure for actionmodules_actionmoduleid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."actionmodules_actionmoduleid_seq";
CREATE SEQUENCE "public"."actionmodules_actionmoduleid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 80
 CACHE 1;
SELECT setval('"public"."actionmodules_actionmoduleid_seq"', 80, true);

-- ----------------------------
-- Sequence structure for actions_actionid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."actions_actionid_seq";
CREATE SEQUENCE "public"."actions_actionid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 4
 CACHE 1;
SELECT setval('"public"."actions_actionid_seq"', 4, true);

-- ----------------------------
-- Sequence structure for basics_id_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."basics_id_seq";
CREATE SEQUENCE "public"."basics_id_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 9
 CACHE 1;
SELECT setval('"public"."basics_id_seq"', 9, true);

-- ----------------------------
-- Sequence structure for modules_moduleid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."modules_moduleid_seq";
CREATE SEQUENCE "public"."modules_moduleid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 20
 CACHE 1;
SELECT setval('"public"."modules_moduleid_seq"', 20, true);

-- ----------------------------
-- Sequence structure for news_newsid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."news_newsid_seq";
CREATE SEQUENCE "public"."news_newsid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 2
 CACHE 1;
SELECT setval('"public"."news_newsid_seq"', 2, true);

-- ----------------------------
-- Sequence structure for photos_photoid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."photos_photoid_seq";
CREATE SEQUENCE "public"."photos_photoid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;

-- ----------------------------
-- Sequence structure for rolerights_rightid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."rolerights_rightid_seq";
CREATE SEQUENCE "public"."rolerights_rightid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 53
 CACHE 1;
SELECT setval('"public"."rolerights_rightid_seq"', 53, true);

-- ----------------------------
-- Sequence structure for roles_roleid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."roles_roleid_seq";
CREATE SEQUENCE "public"."roles_roleid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."roles_roleid_seq"', 1, true);

-- ----------------------------
-- Sequence structure for userroles_userroleid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."userroles_userroleid_seq";
CREATE SEQUENCE "public"."userroles_userroleid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."userroles_userroleid_seq"', 1, true);

-- ----------------------------
-- Sequence structure for users_userid_seq
-- ----------------------------
DROP SEQUENCE IF EXISTS "public"."users_userid_seq";
CREATE SEQUENCE "public"."users_userid_seq"
 INCREMENT 1
 MINVALUE 1
 MAXVALUE 9223372036854775807
 START 1
 CACHE 1;
SELECT setval('"public"."users_userid_seq"', 1, true);

-- ----------------------------
-- Table structure for actionmodules
-- ----------------------------
DROP TABLE IF EXISTS "public"."actionmodules";
CREATE TABLE "public"."actionmodules" (
"actionmoduleid" int4 DEFAULT nextval('actionmodules_actionmoduleid_seq'::regclass) NOT NULL,
"actionid" int4,
"moduleid" int4,
"status" bool
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of actionmodules
-- ----------------------------
INSERT INTO "public"."actionmodules" VALUES ('1', '1', '5', 't');
INSERT INTO "public"."actionmodules" VALUES ('2', '2', '5', 't');
INSERT INTO "public"."actionmodules" VALUES ('3', '3', '5', 't');
INSERT INTO "public"."actionmodules" VALUES ('4', '1', '6', 't');
INSERT INTO "public"."actionmodules" VALUES ('5', '2', '6', 't');
INSERT INTO "public"."actionmodules" VALUES ('6', '3', '6', 't');
INSERT INTO "public"."actionmodules" VALUES ('7', '1', '7', 't');
INSERT INTO "public"."actionmodules" VALUES ('8', '2', '7', 't');
INSERT INTO "public"."actionmodules" VALUES ('9', '3', '7', 't');
INSERT INTO "public"."actionmodules" VALUES ('10', '1', '3', 't');
INSERT INTO "public"."actionmodules" VALUES ('11', '2', '3', 't');
INSERT INTO "public"."actionmodules" VALUES ('12', '3', '3', 't');
INSERT INTO "public"."actionmodules" VALUES ('13', '1', '4', 't');
INSERT INTO "public"."actionmodules" VALUES ('14', '2', '4', 't');
INSERT INTO "public"."actionmodules" VALUES ('15', '3', '4', 't');
INSERT INTO "public"."actionmodules" VALUES ('16', '1', '1', 't');
INSERT INTO "public"."actionmodules" VALUES ('17', '2', '1', 't');
INSERT INTO "public"."actionmodules" VALUES ('18', '3', '1', 't');
INSERT INTO "public"."actionmodules" VALUES ('19', '1', '2', 'f');
INSERT INTO "public"."actionmodules" VALUES ('20', '2', '2', 'f');
INSERT INTO "public"."actionmodules" VALUES ('21', '3', '2', 'f');
INSERT INTO "public"."actionmodules" VALUES ('22', '4', '2', 't');
INSERT INTO "public"."actionmodules" VALUES ('23', '4', '5', 't');
INSERT INTO "public"."actionmodules" VALUES ('24', '4', '6', 't');
INSERT INTO "public"."actionmodules" VALUES ('25', '4', '7', 't');
INSERT INTO "public"."actionmodules" VALUES ('26', '4', '3', 't');
INSERT INTO "public"."actionmodules" VALUES ('27', '4', '4', 't');
INSERT INTO "public"."actionmodules" VALUES ('28', '4', '1', 't');
INSERT INTO "public"."actionmodules" VALUES ('29', '1', '8', 'f');
INSERT INTO "public"."actionmodules" VALUES ('30', '2', '8', 't');
INSERT INTO "public"."actionmodules" VALUES ('31', '3', '8', 'f');
INSERT INTO "public"."actionmodules" VALUES ('32', '4', '8', 't');
INSERT INTO "public"."actionmodules" VALUES ('33', '1', '9', 't');
INSERT INTO "public"."actionmodules" VALUES ('34', '2', '9', 't');
INSERT INTO "public"."actionmodules" VALUES ('35', '3', '9', 't');
INSERT INTO "public"."actionmodules" VALUES ('36', '4', '9', 't');
INSERT INTO "public"."actionmodules" VALUES ('37', '1', '10', 't');
INSERT INTO "public"."actionmodules" VALUES ('38', '2', '10', 't');
INSERT INTO "public"."actionmodules" VALUES ('39', '3', '10', 't');
INSERT INTO "public"."actionmodules" VALUES ('40', '4', '10', 't');
INSERT INTO "public"."actionmodules" VALUES ('41', '1', '11', 't');
INSERT INTO "public"."actionmodules" VALUES ('42', '2', '11', 't');
INSERT INTO "public"."actionmodules" VALUES ('43', '3', '11', 't');
INSERT INTO "public"."actionmodules" VALUES ('44', '4', '11', 't');
INSERT INTO "public"."actionmodules" VALUES ('45', '1', '12', 'f');
INSERT INTO "public"."actionmodules" VALUES ('46', '2', '12', 'f');
INSERT INTO "public"."actionmodules" VALUES ('47', '3', '12', 'f');
INSERT INTO "public"."actionmodules" VALUES ('48', '4', '12', 'f');
INSERT INTO "public"."actionmodules" VALUES ('49', '1', '13', 'f');
INSERT INTO "public"."actionmodules" VALUES ('50', '2', '13', 't');
INSERT INTO "public"."actionmodules" VALUES ('51', '3', '13', 'f');
INSERT INTO "public"."actionmodules" VALUES ('52', '4', '13', 't');
INSERT INTO "public"."actionmodules" VALUES ('53', '1', '14', 'f');
INSERT INTO "public"."actionmodules" VALUES ('54', '2', '14', 't');
INSERT INTO "public"."actionmodules" VALUES ('55', '3', '14', 'f');
INSERT INTO "public"."actionmodules" VALUES ('56', '4', '14', 't');
INSERT INTO "public"."actionmodules" VALUES ('57', '1', '15', 'f');
INSERT INTO "public"."actionmodules" VALUES ('58', '2', '15', 't');
INSERT INTO "public"."actionmodules" VALUES ('59', '3', '15', 'f');
INSERT INTO "public"."actionmodules" VALUES ('60', '4', '15', 't');
INSERT INTO "public"."actionmodules" VALUES ('61', '1', '16', 't');
INSERT INTO "public"."actionmodules" VALUES ('62', '2', '16', 't');
INSERT INTO "public"."actionmodules" VALUES ('63', '3', '16', 't');
INSERT INTO "public"."actionmodules" VALUES ('64', '4', '16', 't');
INSERT INTO "public"."actionmodules" VALUES ('65', '1', '17', 't');
INSERT INTO "public"."actionmodules" VALUES ('66', '2', '17', 't');
INSERT INTO "public"."actionmodules" VALUES ('67', '3', '17', 't');
INSERT INTO "public"."actionmodules" VALUES ('68', '4', '17', 't');
INSERT INTO "public"."actionmodules" VALUES ('69', '1', '18', 't');
INSERT INTO "public"."actionmodules" VALUES ('70', '2', '18', 't');
INSERT INTO "public"."actionmodules" VALUES ('71', '3', '18', 't');
INSERT INTO "public"."actionmodules" VALUES ('72', '4', '18', 't');
INSERT INTO "public"."actionmodules" VALUES ('73', '1', '19', 't');
INSERT INTO "public"."actionmodules" VALUES ('74', '2', '19', 't');
INSERT INTO "public"."actionmodules" VALUES ('75', '3', '19', 't');
INSERT INTO "public"."actionmodules" VALUES ('76', '4', '19', 't');
INSERT INTO "public"."actionmodules" VALUES ('77', '1', '20', 't');
INSERT INTO "public"."actionmodules" VALUES ('78', '2', '20', 't');
INSERT INTO "public"."actionmodules" VALUES ('79', '3', '20', 't');
INSERT INTO "public"."actionmodules" VALUES ('80', '4', '20', 't');

-- ----------------------------
-- Table structure for actions
-- ----------------------------
DROP TABLE IF EXISTS "public"."actions";
CREATE TABLE "public"."actions" (
"actionid" int4 DEFAULT nextval('actions_actionid_seq'::regclass) NOT NULL,
"actioncode" varchar(50) COLLATE "default",
"displayname" varchar(50) COLLATE "default",
"seqno" int4,
"description" varchar(500) COLLATE "default",
"createdby" varchar(50) COLLATE "default",
"createdtime" timestamp(6),
"changedby" varchar(50) COLLATE "default",
"changedtime" timestamp(6)
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of actions
-- ----------------------------
INSERT INTO "public"."actions" VALUES ('1', 'Add', '新增', '1', '新增', 'admin', '2015-05-26 04:31:06.166224', null, null);
INSERT INTO "public"."actions" VALUES ('2', 'Edit', '编辑', '2', '编辑', 'admin', '2015-05-26 04:31:24.511969', null, null);
INSERT INTO "public"."actions" VALUES ('3', 'Delete', '删除', '3', '删除', 'admin', '2015-05-26 04:31:39.593803', null, null);
INSERT INTO "public"."actions" VALUES ('4', 'Display', '显示', '4', '显示', 'admin', '2015-05-26 04:44:52.503221', null, null);

-- ----------------------------
-- Table structure for basics
-- ----------------------------
DROP TABLE IF EXISTS "public"."basics";
CREATE TABLE "public"."basics" (
"id" int4 DEFAULT nextval('basics_id_seq'::regclass) NOT NULL,
"key" varchar(50) COLLATE "default",
"value" varchar(400) COLLATE "default"
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of basics
-- ----------------------------
INSERT INTO "public"."basics" VALUES ('1', 'pagesize', '10');
INSERT INTO "public"."basics" VALUES ('2', 'company_name', '上海戴氏木业有限责任公司');
INSERT INTO "public"."basics" VALUES ('3', 'website_url', 'ttp://localhost:18098/');
INSERT INTO "public"."basics" VALUES ('4', 'address', '22');
INSERT INTO "public"."basics" VALUES ('5', 'telphone', '1');
INSERT INTO "public"."basics" VALUES ('6', 'email', '1');
INSERT INTO "public"."basics" VALUES ('7', 'fax', '1');
INSERT INTO "public"."basics" VALUES ('8', 'zipcode', '1');
INSERT INTO "public"."basics" VALUES ('9', 'icp', '粤ICP备13024775号-1');

-- ----------------------------
-- Table structure for modules
-- ----------------------------
DROP TABLE IF EXISTS "public"."modules";
CREATE TABLE "public"."modules" (
"moduleid" int4 DEFAULT nextval('modules_moduleid_seq'::regclass) NOT NULL,
"parentid" int4,
"modulecode" varchar(50) COLLATE "default",
"displayname" varchar(50) COLLATE "default",
"displayasmenu" bool,
"websitefrontmenu" bool,
"article" bool,
"classname" varchar(20) COLLATE "default",
"url" varchar(100) COLLATE "default",
"fronturl" varchar(100) COLLATE "default",
"seqno" int4,
"description" varchar(500) COLLATE "default",
"createdby" varchar(50) COLLATE "default",
"createdtime" timestamp(6),
"changedby" varchar(50) COLLATE "default",
"changedtime" timestamp(6)
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of modules
-- ----------------------------
INSERT INTO "public"."modules" VALUES ('1', '0', 'Dashboard', '信息汇总', 't', 'f', 'f', 'fa fa-dashboard', '~/Admin/Dashboard/Index', null, '1', null, null, null, 'admin', '2015-05-26 09:05:01.145835');
INSERT INTO "public"."modules" VALUES ('2', '0', 'Setup', '设置', 't', 'f', 'f', 'fa fa-cog', null, null, '2', null, null, null, 'admin', '2015-05-26 09:05:48.636672');
INSERT INTO "public"."modules" VALUES ('3', '2', 'Users', 'Users', 't', 'f', 'f', null, '~/Admin/Users/Index', null, '1000', null, null, null, 'admin', '2015-05-26 05:48:36.082746');
INSERT INTO "public"."modules" VALUES ('4', '2', 'Roles', 'Roles', 't', 'f', 'f', null, '~/Admin/Roles/Index', null, '1100', null, null, null, 'admin', '2015-05-26 05:49:03.669904');
INSERT INTO "public"."modules" VALUES ('5', '2', 'Actions', 'Actions', 't', 'f', 'f', null, '~/Admin/Actions/Index', null, '999', null, null, null, 'admin', '2015-05-26 05:48:52.081117');
INSERT INTO "public"."modules" VALUES ('6', '2', 'Modules', 'Modules', 't', 'f', 'f', null, '~/Admin/Modules/Index', null, '1200', null, null, null, 'admin', '2015-05-26 05:49:21.289224');
INSERT INTO "public"."modules" VALUES ('7', '2', 'RoleRights', 'RoleRights', 't', 'f', 'f', null, '~/Admin/RoleRights/Index', null, '1300', null, null, null, 'admin', '2015-05-26 05:49:27.03559');
INSERT INTO "public"."modules" VALUES ('8', '0', 'aboutus', '关于我们', 't', 't', 't', 'fa fa-building-o', '~/Admin/About/Index', '~/About/Index?ModuleId=12&ParentId=11', '4', null, 'admin', '2015-05-26 08:34:18.626354', null, null);
INSERT INTO "public"."modules" VALUES ('9', '0', 'News', '新闻资讯', 't', 't', 't', 'fa fa-newspaper-o', '~/Admin/News/Index', '~/News/Index?ModuleId=15&ParentId=16', '5', null, 'admin', '2015-05-26 08:37:52.904505', null, null);
INSERT INTO "public"."modules" VALUES ('10', '0', 'Cases', '客户案例', 't', 't', 'f', 'fa fa-picture-o', '~/Admin/Cases/Index', '~/Cases/Index?ModuleId=19&ParentId=18', '6', null, 'admin', '2015-05-26 08:50:59.132807', null, null);
INSERT INTO "public"."modules" VALUES ('11', '0', 'Products', '产品展示', 't', 't', 't', 'fa fa-reorder', '~/Admin/Products/Index', '~/Products/Index?ModuleId=22&ParentId=21', '7', null, 'admin', '2015-05-26 08:51:55.059243', null, null);
INSERT INTO "public"."modules" VALUES ('12', '0', 'Home', '首页', 'f', 't', 'f', null, null, '~/Home/Index', '3', null, 'admin', '2015-05-26 08:53:12.151721', null, null);
INSERT INTO "public"."modules" VALUES ('13', '8', 'introduce', '公司简介', 'f', 't', 't', null, null, '~/About/Index', '1', null, 'admin', '2015-05-26 08:54:25.603048', null, null);
INSERT INTO "public"."modules" VALUES ('14', '8', 'qualification', '公司资质', 'f', 't', 't', null, '~/About/Index', null, '3', null, 'admin', '2015-05-26 08:55:38.816874', null, null);
INSERT INTO "public"."modules" VALUES ('15', '8', 'contact', '联系我们', 'f', 't', 't', null, null, '~/About/Index', '3', null, 'admin', '2015-05-26 08:56:09.861829', null, null);
INSERT INTO "public"."modules" VALUES ('16', '9', 'CompanyNews', '公司新闻', 'f', 't', 't', null, null, '~/News/Index', '1', null, 'admin', '2015-05-26 08:56:57.639021', null, null);
INSERT INTO "public"."modules" VALUES ('17', '10', 'handrail', '扶手安装案例', 'f', 't', 't', null, null, '~/Cases/Index', '1', null, 'admin', '2015-05-26 08:57:58.73215', null, null);
INSERT INTO "public"."modules" VALUES ('18', '10', 'waterpurifier', '净水器安装案例', 'f', 't', 't', null, null, '~/Cases/Index', '2', null, 'admin', '2015-05-26 08:58:47.804657', null, null);
INSERT INTO "public"."modules" VALUES ('19', '11', 'Prodhandrail', '精品扶手', 'f', 't', 't', null, null, '~/Products/Index', '1', null, 'admin', '2015-05-26 09:02:09.291038', null, null);
INSERT INTO "public"."modules" VALUES ('20', '11', 'waterclarifier', '净水器', 'f', 't', 't', null, null, '~/Products/Index', '2', null, 'admin', '2015-05-26 09:02:39.743411', null, null);

-- ----------------------------
-- Table structure for news
-- ----------------------------
DROP TABLE IF EXISTS "public"."news";
CREATE TABLE "public"."news" (
"newsid" int4 DEFAULT nextval('news_newsid_seq'::regclass) NOT NULL,
"parentid" int4,
"moduleid" int4,
"title" varchar(200) COLLATE "default",
"author" varchar(50) COLLATE "default",
"source" varchar(100) COLLATE "default",
"brief" varchar(300) COLLATE "default",
"content" text COLLATE "default",
"count" int4,
"createdby" varchar(50) COLLATE "default",
"createdtime" timestamp(6),
"changedby" varchar(50) COLLATE "default",
"changedtime" timestamp(6)
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of news
-- ----------------------------
INSERT INTO "public"."news" VALUES ('1', '9', '16', 'test', null, null, null, null, '0', 'admin', '2015-05-26 09:24:10.093296', null, null);
INSERT INTO "public"."news" VALUES ('2', '9', '16', 'test', 'test', null, null, null, '0', 'admin', '2015-05-26 09:24:21.700518', null, null);

-- ----------------------------
-- Table structure for photos
-- ----------------------------
DROP TABLE IF EXISTS "public"."photos";
CREATE TABLE "public"."photos" (
"photoid" int4 DEFAULT nextval('photos_photoid_seq'::regclass) NOT NULL,
"newsid" int4,
"thumbnail" varchar(200) COLLATE "default",
"original" varchar(200) COLLATE "default",
"publishhome" bool,
"description" varchar(400) COLLATE "default"
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of photos
-- ----------------------------

-- ----------------------------
-- Table structure for rolerights
-- ----------------------------
DROP TABLE IF EXISTS "public"."rolerights";
CREATE TABLE "public"."rolerights" (
"rightid" int4 DEFAULT nextval('rolerights_rightid_seq'::regclass) NOT NULL,
"roleid" int4,
"actionmoduleid" int4,
"status" bool
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of rolerights
-- ----------------------------
INSERT INTO "public"."rolerights" VALUES ('1', '1', '16', 't');
INSERT INTO "public"."rolerights" VALUES ('2', '1', '17', 't');
INSERT INTO "public"."rolerights" VALUES ('3', '1', '18', 't');
INSERT INTO "public"."rolerights" VALUES ('4', '1', '19', 'f');
INSERT INTO "public"."rolerights" VALUES ('5', '1', '20', 'f');
INSERT INTO "public"."rolerights" VALUES ('6', '1', '21', 'f');
INSERT INTO "public"."rolerights" VALUES ('7', '1', '22', 't');
INSERT INTO "public"."rolerights" VALUES ('8', '1', '10', 't');
INSERT INTO "public"."rolerights" VALUES ('9', '1', '11', 't');
INSERT INTO "public"."rolerights" VALUES ('10', '1', '12', 't');
INSERT INTO "public"."rolerights" VALUES ('11', '1', '13', 't');
INSERT INTO "public"."rolerights" VALUES ('12', '1', '14', 't');
INSERT INTO "public"."rolerights" VALUES ('13', '1', '15', 't');
INSERT INTO "public"."rolerights" VALUES ('14', '1', '1', 't');
INSERT INTO "public"."rolerights" VALUES ('15', '1', '2', 't');
INSERT INTO "public"."rolerights" VALUES ('16', '1', '3', 't');
INSERT INTO "public"."rolerights" VALUES ('17', '1', '4', 't');
INSERT INTO "public"."rolerights" VALUES ('18', '1', '5', 't');
INSERT INTO "public"."rolerights" VALUES ('19', '1', '6', 't');
INSERT INTO "public"."rolerights" VALUES ('20', '1', '7', 't');
INSERT INTO "public"."rolerights" VALUES ('21', '1', '8', 't');
INSERT INTO "public"."rolerights" VALUES ('22', '1', '9', 't');
INSERT INTO "public"."rolerights" VALUES ('23', '1', '19', 'f');
INSERT INTO "public"."rolerights" VALUES ('24', '1', '20', 'f');
INSERT INTO "public"."rolerights" VALUES ('25', '1', '21', 'f');
INSERT INTO "public"."rolerights" VALUES ('26', '1', '26', 't');
INSERT INTO "public"."rolerights" VALUES ('27', '1', '27', 't');
INSERT INTO "public"."rolerights" VALUES ('28', '1', '23', 't');
INSERT INTO "public"."rolerights" VALUES ('29', '1', '24', 't');
INSERT INTO "public"."rolerights" VALUES ('30', '1', '25', 't');
INSERT INTO "public"."rolerights" VALUES ('31', '1', '28', 't');
INSERT INTO "public"."rolerights" VALUES ('32', '1', '19', 'f');
INSERT INTO "public"."rolerights" VALUES ('33', '1', '20', 'f');
INSERT INTO "public"."rolerights" VALUES ('34', '1', '21', 'f');
INSERT INTO "public"."rolerights" VALUES ('35', '1', '19', 'f');
INSERT INTO "public"."rolerights" VALUES ('36', '1', '20', 'f');
INSERT INTO "public"."rolerights" VALUES ('37', '1', '21', 'f');
INSERT INTO "public"."rolerights" VALUES ('38', '1', '29', 'f');
INSERT INTO "public"."rolerights" VALUES ('39', '1', '30', 't');
INSERT INTO "public"."rolerights" VALUES ('40', '1', '31', 'f');
INSERT INTO "public"."rolerights" VALUES ('41', '1', '32', 't');
INSERT INTO "public"."rolerights" VALUES ('42', '1', '33', 't');
INSERT INTO "public"."rolerights" VALUES ('43', '1', '34', 't');
INSERT INTO "public"."rolerights" VALUES ('44', '1', '35', 't');
INSERT INTO "public"."rolerights" VALUES ('45', '1', '36', 't');
INSERT INTO "public"."rolerights" VALUES ('46', '1', '37', 't');
INSERT INTO "public"."rolerights" VALUES ('47', '1', '38', 't');
INSERT INTO "public"."rolerights" VALUES ('48', '1', '39', 't');
INSERT INTO "public"."rolerights" VALUES ('49', '1', '40', 't');
INSERT INTO "public"."rolerights" VALUES ('50', '1', '41', 't');
INSERT INTO "public"."rolerights" VALUES ('51', '1', '42', 't');
INSERT INTO "public"."rolerights" VALUES ('52', '1', '43', 't');
INSERT INTO "public"."rolerights" VALUES ('53', '1', '44', 't');

-- ----------------------------
-- Table structure for roles
-- ----------------------------
DROP TABLE IF EXISTS "public"."roles";
CREATE TABLE "public"."roles" (
"roleid" int4 DEFAULT nextval('roles_roleid_seq'::regclass) NOT NULL,
"rolecode" varchar(50) COLLATE "default" NOT NULL,
"displayname" varchar(50) COLLATE "default",
"seqno" int4,
"description" varchar(500) COLLATE "default",
"createdby" varchar(50) COLLATE "default",
"createdtime" timestamp(6),
"changedby" varchar(50) COLLATE "default",
"changedtime" timestamp(6)
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of roles
-- ----------------------------
INSERT INTO "public"."roles" VALUES ('1', 'SuperUser', '超级管理员', '1000', '超级管理员', 'admin', '2015-05-26 04:32:26.412213', null, null);

-- ----------------------------
-- Table structure for userroles
-- ----------------------------
DROP TABLE IF EXISTS "public"."userroles";
CREATE TABLE "public"."userroles" (
"userroleid" int4 DEFAULT nextval('userroles_userroleid_seq'::regclass) NOT NULL,
"userid" int4,
"roleid" int4,
"status" bool
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of userroles
-- ----------------------------
INSERT INTO "public"."userroles" VALUES ('1', '1', '1', 't');

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS "public"."users";
CREATE TABLE "public"."users" (
"userid" int4 DEFAULT nextval('users_userid_seq'::regclass) NOT NULL,
"username" varchar(50) COLLATE "default",
"password" varchar(50) COLLATE "default",
"email" varchar(100) COLLATE "default",
"firstname" varchar(50) COLLATE "default",
"lastname" varchar(50) COLLATE "default",
"language" varchar(50) COLLATE "default",
"createdby" varchar(50) COLLATE "default",
"createdtime" timestamp(6),
"changedby" varchar(50) COLLATE "default",
"changedtime" timestamp(6)
)
WITH (OIDS=FALSE)

;

-- ----------------------------
-- Records of users
-- ----------------------------
INSERT INTO "public"."users" VALUES ('1', 'admin', 'F379A41AC0FD2D15473AC019E26B6', 'dc0106@126.com', 'carl', 'dai', null, null, null, 'admin', '2015-05-26 05:52:47.754154');

-- ----------------------------
-- Alter Sequences Owned By 
-- ----------------------------
ALTER SEQUENCE "public"."actionmodules_actionmoduleid_seq" OWNED BY "actionmodules"."actionmoduleid";
ALTER SEQUENCE "public"."actions_actionid_seq" OWNED BY "actions"."actionid";
ALTER SEQUENCE "public"."basics_id_seq" OWNED BY "basics"."id";
ALTER SEQUENCE "public"."modules_moduleid_seq" OWNED BY "modules"."moduleid";
ALTER SEQUENCE "public"."news_newsid_seq" OWNED BY "news"."newsid";
ALTER SEQUENCE "public"."photos_photoid_seq" OWNED BY "photos"."photoid";
ALTER SEQUENCE "public"."rolerights_rightid_seq" OWNED BY "rolerights"."rightid";
ALTER SEQUENCE "public"."roles_roleid_seq" OWNED BY "roles"."roleid";
ALTER SEQUENCE "public"."userroles_userroleid_seq" OWNED BY "userroles"."userroleid";
ALTER SEQUENCE "public"."users_userid_seq" OWNED BY "users"."userid";

-- ----------------------------
-- Primary Key structure for table actionmodules
-- ----------------------------
ALTER TABLE "public"."actionmodules" ADD PRIMARY KEY ("actionmoduleid");

-- ----------------------------
-- Uniques structure for table actions
-- ----------------------------
ALTER TABLE "public"."actions" ADD UNIQUE ("actioncode");

-- ----------------------------
-- Primary Key structure for table actions
-- ----------------------------
ALTER TABLE "public"."actions" ADD PRIMARY KEY ("actionid");

-- ----------------------------
-- Uniques structure for table basics
-- ----------------------------
ALTER TABLE "public"."basics" ADD UNIQUE ("key");

-- ----------------------------
-- Primary Key structure for table basics
-- ----------------------------
ALTER TABLE "public"."basics" ADD PRIMARY KEY ("id");

-- ----------------------------
-- Uniques structure for table modules
-- ----------------------------
ALTER TABLE "public"."modules" ADD UNIQUE ("modulecode");

-- ----------------------------
-- Primary Key structure for table modules
-- ----------------------------
ALTER TABLE "public"."modules" ADD PRIMARY KEY ("moduleid");

-- ----------------------------
-- Indexes structure for table news
-- ----------------------------
CREATE INDEX "idx_moduleid" ON "public"."news" USING btree (moduleid);
CREATE UNIQUE INDEX "idx_newsid_moduleid" ON "public"."news" USING btree (newsid, moduleid);
CREATE INDEX "idx_title" ON "public"."news" USING btree (title);

-- ----------------------------
-- Primary Key structure for table news
-- ----------------------------
ALTER TABLE "public"."news" ADD PRIMARY KEY ("newsid");

-- ----------------------------
-- Primary Key structure for table photos
-- ----------------------------
ALTER TABLE "public"."photos" ADD PRIMARY KEY ("photoid");

-- ----------------------------
-- Primary Key structure for table rolerights
-- ----------------------------
ALTER TABLE "public"."rolerights" ADD PRIMARY KEY ("rightid");

-- ----------------------------
-- Indexes structure for table roles
-- ----------------------------
CREATE UNIQUE INDEX "idx_roleid_rolecode" ON "public"."roles" USING btree (roleid, rolecode);

-- ----------------------------
-- Uniques structure for table roles
-- ----------------------------
ALTER TABLE "public"."roles" ADD UNIQUE ("rolecode");

-- ----------------------------
-- Primary Key structure for table roles
-- ----------------------------
ALTER TABLE "public"."roles" ADD PRIMARY KEY ("roleid");

-- ----------------------------
-- Primary Key structure for table userroles
-- ----------------------------
ALTER TABLE "public"."userroles" ADD PRIMARY KEY ("userroleid");

-- ----------------------------
-- Indexes structure for table users
-- ----------------------------
CREATE UNIQUE INDEX "idx_userid_username_email" ON "public"."users" USING btree (userid, username, email);

-- ----------------------------
-- Uniques structure for table users
-- ----------------------------
ALTER TABLE "public"."users" ADD UNIQUE ("username");
ALTER TABLE "public"."users" ADD UNIQUE ("email");

-- ----------------------------
-- Primary Key structure for table users
-- ----------------------------
ALTER TABLE "public"."users" ADD PRIMARY KEY ("userid");

-- ----------------------------
-- Foreign Key structure for table "public"."actionmodules"
-- ----------------------------
ALTER TABLE "public"."actionmodules" ADD FOREIGN KEY ("moduleid") REFERENCES "public"."modules" ("moduleid") ON DELETE CASCADE ON UPDATE RESTRICT;
ALTER TABLE "public"."actionmodules" ADD FOREIGN KEY ("actionid") REFERENCES "public"."actions" ("actionid") ON DELETE CASCADE ON UPDATE RESTRICT;

-- ----------------------------
-- Foreign Key structure for table "public"."news"
-- ----------------------------
ALTER TABLE "public"."news" ADD FOREIGN KEY ("moduleid") REFERENCES "public"."modules" ("moduleid") ON DELETE NO ACTION ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."photos"
-- ----------------------------
ALTER TABLE "public"."photos" ADD FOREIGN KEY ("newsid") REFERENCES "public"."news" ("newsid") ON DELETE CASCADE ON UPDATE NO ACTION;

-- ----------------------------
-- Foreign Key structure for table "public"."rolerights"
-- ----------------------------
ALTER TABLE "public"."rolerights" ADD FOREIGN KEY ("actionmoduleid") REFERENCES "public"."actionmodules" ("actionmoduleid") ON DELETE CASCADE ON UPDATE RESTRICT;
ALTER TABLE "public"."rolerights" ADD FOREIGN KEY ("roleid") REFERENCES "public"."roles" ("roleid") ON DELETE CASCADE ON UPDATE RESTRICT;

-- ----------------------------
-- Foreign Key structure for table "public"."userroles"
-- ----------------------------
ALTER TABLE "public"."userroles" ADD FOREIGN KEY ("roleid") REFERENCES "public"."roles" ("roleid") ON DELETE CASCADE ON UPDATE RESTRICT;
ALTER TABLE "public"."userroles" ADD FOREIGN KEY ("userid") REFERENCES "public"."users" ("userid") ON DELETE CASCADE ON UPDATE RESTRICT;
