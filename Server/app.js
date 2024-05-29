const express = require('express');
const config = require('./config/config.json');
const requstHandlers = require('./requestHandlers');
const app = express();

//aguarda pelo pedido feito pelo cliente para: /getPlayerStatus
//com o verbo HTTP: get
app.get('/getPlayerStatus', requstHandlers.getPlayerStats);

app.listen(config.server.port, function()  
{
    console.log(`Servidor á escuta em: ${config.server.host}: ${config.server.port}`); // mensagem para saber se o servidor está á escuta 
});