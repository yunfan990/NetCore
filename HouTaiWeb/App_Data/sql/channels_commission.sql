DROP TABLE IF EXISTS `channels_commission`;
CREATE TABLE `channels_commission` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `ChannelsID` int(11) DEFAULT NULL,
  `Money` int(11) DEFAULT NULL,
  `CId` int(11) DEFAULT NULL,
  `TaxMoney` int(11) DEFAULT NULL,
  `Proportions` varchar(255) DEFAULT NULL COMMENT '分成比例',
  `BaseCharge` varchar(255) DEFAULT NULL,
  `Detail` varchar(255) DEFAULT NULL COMMENT '备注',
  `AddTime` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
