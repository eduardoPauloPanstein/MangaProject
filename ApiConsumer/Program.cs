using ApiConsumer;

ApiConnect apiConnect = new ();
await apiConnect.Consume(100);
//apiConnect.DeleteAllDatas();

//TODO: Conferir dados que vem nulos. Exp: se não tiver imagem não quero  