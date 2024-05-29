const mysql = require('mysql2');
const config = require('./config/config.json');

const connectionOpinion = config.database;

function getPlayerStats(request, response) 
{
    let connection = mysql.createConnection(connectionOpinion);
    connection.connect();
    connection.query
    (
        'SELECT * FROM playerdata',
        function(error, rows) 
        {
            if (error) 
            {
                console.log("Erro na Base de Dados:" + error.message);
                response.status(500);
            } 
            else 
            {
                console.log("Rows: " , rows);
                response.send(
                    JSON.stringify
                    (
                        {
                            "playerDataValues": rows
                        }
                    )
                );
            }
        }
    );
    connection.end();
}    

module.exports.getPlayerStats = getPlayerStats;