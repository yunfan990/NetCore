
CREATE TABLE `promoter_commission` (
  `ID` int(11) NOT NULL AUTO_INCREMENT COMMENT '推广员分成记录表',
  `PromoterID` int(11) DEFAULT NULL COMMENT '推广员ID',
  `Money` int(11) DEFAULT NULL COMMENT '当前推广员分成金额',
  `CId` int(11) DEFAULT NULL COMMENT '角色ID',
  `TaxMoney` int(11) DEFAULT NULL COMMENT '总分成金额',
  `Proportions` varchar(255) DEFAULT NULL COMMENT '分成链',
  `AddTime` datetime DEFAULT NULL COMMENT '游戏记录时间',
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=299 DEFAULT CHARSET=utf8;
