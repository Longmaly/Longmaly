/*
 Navicat Premium Data Transfer

 Source Server         : local
 Source Server Type    : PostgreSQL
 Source Server Version : 110004
 Source Host           : localhost:5432
 Source Catalog        : demodb
 Source Schema         : public

 Target Server Type    : PostgreSQL
 Target Server Version : 110004
 File Encoding         : 65001

 Date: 04/11/2021 12:15:35
*/


-- ----------------------------
-- Table structure for User
-- ----------------------------
DROP TABLE IF EXISTS "User";
CREATE TABLE "User" (
  "Id" uuid NOT NULL,
  "FirstName" varchar(50) COLLATE "pg_catalog"."default",
  "LastName" varchar(50) COLLATE "pg_catalog"."default",
  "Sex" varchar(10) COLLATE "pg_catalog"."default",
  "Addresses" varchar(255) COLLATE "pg_catalog"."default"
)
;

-- ----------------------------
-- Records of User
-- ----------------------------
BEGIN;
COMMIT;
