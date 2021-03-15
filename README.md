# Finances
Aplicação de controle financeira desenvonvida com Blazor e .Net 5.

## Modos de executar


Faça o clone do repositório utilizando o seguinte comando:
```
git clone https://github.com/JoaoPauloRB/Finances.git
```
E então entre na pasta do projeto com o comando: 
```
cd Finances
```

### Usando docker
Para executar a apicação utilizando [docker](https://www.docker.com/), faça o build do projeto utilizando o comando:

```
docker-compose build
```

Após ele executar, execute o seguinte comando para rodar a aplicação:
```
docker-compose up
```

### Rodando da aplicação via sdk
Para rodar a aplicação dessa forma é necessário instalar o sdk [dotnet](https://dotnet.microsoft.com/download/dotnet/5.0) e 
configurá-lo nas variáveis de ambiente.

para executar a api da aplicação execute o comando:
```
cd Application
dotnet restore
dotnet run
```

e para executar o front-end da aplicação execute o seguinte comando:
para executar a api da aplicação execute o comando:
```
cd Web
dotnet restore
dotnet run
```
