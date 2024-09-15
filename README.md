# **Worker Services**

Também chamados de serviços de longa execução, nada mais são do que aplicações que rodam por tempo indefinido, em segundo plano, executando tarefas onde os usuários não veem.

Em versões anteriores, eram criados “Windows Services Applications” ou “Console Applications” para esta finalidade, mas a partir do .NET 3 foram disponibilizados os modelos de Worker Service Applications para esta finalidade.

Eles podem ser usados para monitorar filas de execução, tabelas de bancos de dados, serviços para envio de e-mails, validação de status de serviços de terceiros, entre muitas outras funcionalidades.

Caso seu servidor seja um servidor Windows, é necessário realizar uma implementação específica:

Primeiro, adicione um pacote nuget: **Microsoft.Extensions.Hosting.WindowsServices**

Depois, precisamos alterar o program.cs inserindo uma instrução para que ele possa se comportar como um Windows Service.

![image](https://github.com/user-attachments/assets/29bcc51f-2705-4876-af1b-83007ae395cc)

Além disso, vamos implementar no Worker.cs uma sobrecarga de dois métodos:

![image](https://github.com/user-attachments/assets/eec979ab-7e33-405e-be32-f8b91d081850)

Neste exemplo é demonstrado como fazer com que um Worker Service execute numa hora específica do dia e fique rodando para execução diária naquele horário.
