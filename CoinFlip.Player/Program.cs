// See https://aka.ms/new-console-template for more information
using CoinFlip.Engine;


Game loader = new();
FileStream json = new(args[0], FileMode.Open);
Game game = await loader.Load(json);
