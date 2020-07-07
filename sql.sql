USE esport;


CREATE VIEW  playerinfo(id,nickname, ФИО, date, rang,  club, country)
As 
SELECT playerID, nickname, fullname , dateofbirth, player.rank, gc.name, ct.nameCountry  FROM esport.player
join game_club as gc
on (gc.idGame_club = esport.player.`Game_club_idGame club`)
join esport.сountries as ct
on (ct.idСountries = player.сountrie_id); 

SELECT * FROM playerinfo;


CREATE VIEW tournamentinfo (a, b, c, d, e, f, g, h, i, j ,k, l, m )
As
SELECT dis.name_discipline, name_tournament, st.status, c.Cityname, URL, stream, winner, place2, place3, datestart, dateend, sponsor, prizepool FROM esport.tournament
join esport.discipline as dis
on (dis.id_discipline = tournament.discipline_id)
join esport.status_turnira as st
on (st.statusid = tournament.status_statusid)
join esport.city as c
on (c.idcity = tournament.City_idcity); 

SELECT * FROM tournamentinfo;


CREATE VIEW teamInfo (playerID, nickname, gameClub)
As
SELECT playerID, nickname, gc.name FROM esport.player
join esport.game_club as gc
on (gc.idGame_club = player.`Game_club_idGame club`);

SELECT * FROM teamInfo;


CREATE VIEW teamByDiscipline (discipline, gameClub)
As
SELECT d.name_discipline , name FROM esport.game_club
join esport.game_club_has_discipline as gchd
on (gchd.`Game_club_idGame club` = game_club.idGame_club)
join esport.discipline as d
on (gchd.discipline_id_discipline = d.id_discipline);

SELECT * FROM teamByDiscipline;


CREATE VIEW disc (a, b, c, d, e)
As
SELECT idtournament,name_tournament , dis.name_discipline, status_statusid, datestart  FROM esport.tournament
join esport.discipline as dis
on (dis.id_discipline = tournament.discipline_id);

SELECT * FROM disc;



