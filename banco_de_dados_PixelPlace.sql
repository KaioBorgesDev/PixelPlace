-- MySQL Script generated by MySQL Workbench
-- Tue Apr 30 16:53:54 2024
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `mydb`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT,
  `nomeUser` VARCHAR(45) NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `senha` VARCHAR(45) NOT NULL,
  `imagem` BLOB NULL,
  PRIMARY KEY (`idUsuario`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Jogo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Jogo` (
  `idJogo` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NOT NULL,
  `imagem` VARCHAR(45) NOT NULL,
  `descricao` VARCHAR(45) NOT NULL,
  `categoria` VARCHAR(45) NOT NULL,
  `preco` DOUBLE NOT NULL,
  `desconto` DOUBLE NULL DEFAULT 0,
  `data_lancamento` DATETIME NOT NULL,
  `num_avaliacao` INT NULL DEFAULT 0,
  `num_estrelas` VARCHAR(45) NULL DEFAULT 0,
  `desenvolvedora` VARCHAR(45) NOT NULL,
  `jogo_destaque` INT NULL DEFAULT 0,
  PRIMARY KEY (`idJogo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Biblioteca`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Biblioteca` (
  `Usuario_idUsuario` INT NOT NULL,
  `Jogo_idJogo` INT NOT NULL,
  PRIMARY KEY (`Usuario_idUsuario`, `Jogo_idJogo`),
  INDEX `fk_Usuario_has_Jogo_Jogo1_idx` (`Jogo_idJogo` ASC) VISIBLE,
  INDEX `fk_Usuario_has_Jogo_Usuario_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Usuario_has_Jogo_Usuario`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `mydb`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuario_has_Jogo_Jogo1`
    FOREIGN KEY (`Jogo_idJogo`)
    REFERENCES `mydb`.`Jogo` (`idJogo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Favoritos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Favoritos` (
  `Usuario_idUsuario` INT NOT NULL,
  `Jogo_idJogo` INT NOT NULL,
  PRIMARY KEY (`Usuario_idUsuario`, `Jogo_idJogo`),
  INDEX `fk_Usuario_has_Jogo_Jogo2_idx` (`Jogo_idJogo` ASC) VISIBLE,
  INDEX `fk_Usuario_has_Jogo_Usuario1_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Usuario_has_Jogo_Usuario1`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `mydb`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuario_has_Jogo_Jogo2`
    FOREIGN KEY (`Jogo_idJogo`)
    REFERENCES `mydb`.`Jogo` (`idJogo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Transacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Transacao` (
  `Usuario_idUsuario` INT NOT NULL,
  `Jogo_idJogo` INT NOT NULL,
  `data_transacao` DATETIME NOT NULL,
  `valor_total` DOUBLE NOT NULL,
  `metodo_pagamento` VARCHAR(45) NOT NULL,
  `tipo_compra` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Usuario_idUsuario`, `Jogo_idJogo`),
  INDEX `fk_Usuario_has_Jogo_Jogo3_idx` (`Jogo_idJogo` ASC) VISIBLE,
  INDEX `fk_Usuario_has_Jogo_Usuario2_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Usuario_has_Jogo_Usuario2`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `mydb`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuario_has_Jogo_Jogo3`
    FOREIGN KEY (`Jogo_idJogo`)
    REFERENCES `mydb`.`Jogo` (`idJogo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Cupons_Desconto`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Cupons_Desconto` (
  `cupom` INT NOT NULL,
  `porcertagem_desconto` INT NOT NULL,
  PRIMARY KEY (`cupom`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Carrinho`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Carrinho` (
  `Usuario_idUsuario` INT NOT NULL,
  `Jogo_idJogo` INT NOT NULL,
  `Cupons_Desconto_cupom` INT NULL,
  PRIMARY KEY (`Usuario_idUsuario`, `Jogo_idJogo`),
  INDEX `fk_Usuario_has_Jogo_Jogo4_idx` (`Jogo_idJogo` ASC) VISIBLE,
  INDEX `fk_Usuario_has_Jogo_Usuario3_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  INDEX `fk_Carrinho_Cupons_Desconto1_idx` (`Cupons_Desconto_cupom` ASC) VISIBLE,
  CONSTRAINT `fk_Usuario_has_Jogo_Usuario3`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `mydb`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuario_has_Jogo_Jogo4`
    FOREIGN KEY (`Jogo_idJogo`)
    REFERENCES `mydb`.`Jogo` (`idJogo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Carrinho_Cupons_Desconto1`
    FOREIGN KEY (`Cupons_Desconto_cupom`)
    REFERENCES `mydb`.`Cupons_Desconto` (`cupom`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Notificacao`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `mydb`.`Notificacao` (
  `mensagem` INT NOT NULL,
  `Usuario_idUsuario` INT NOT NULL,
  PRIMARY KEY (`mensagem`, `Usuario_idUsuario`),
  INDEX `fk_Notificacao_Usuario1_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Notificacao_Usuario1`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `mydb`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
