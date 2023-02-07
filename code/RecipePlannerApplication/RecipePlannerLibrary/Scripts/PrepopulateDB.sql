create table if not exists login(username varchar(30), `password` varchar(255));
insert ignore into login values('global', MD5('user')), ('admin', MD5('123'));


