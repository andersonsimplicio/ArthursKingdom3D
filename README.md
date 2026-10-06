
# ArthursKingdom3D 🎮 
Um jogo 3D desenvolvido com Unity, criado como um projeto para explorar desenvolvimento de jogos, programação, design de níveis e criação de ambientes.

🕹️ Sobre o jogo

Descrição:
Uma Lenda Medieval.

✨ Principais características

🌍 Ambiente 3D

🎮 Controle do personagem

🗺️ Exploração e/ou fases

⚔️ Sistema de combate

🎯 Objetivos e desafios

🔊 Áudio e efeitos sonoros

Adicione ou remova características conforme o desenvolvimento do jogo.

🛠️ Tecnologias

Unity: 6.5

C#: Linguagem de programação

Git: Controle de versão

GitHub: Hospedagem do código-fonte
```text
📁 Estrutura do projeto
MeuJogo3D/
├── Assets/
│   ├── Animations/
│   ├── Audio/
│   ├── Materials/
│   ├── Models/
│   ├── Prefabs/
│   ├── Scenes/
│   ├── Scripts/
│   ├── Textures/
│   └── UI/
├── Packages/
├── ProjectSettings/
├── .gitignore
└── README.md
```
🎮 Controles
Ação	Tecla
Mover para frente	W
Mover para trás	S
Mover para esquerda	A
Mover para direita	D
Pular	Space
Correr	Shift
Interagir	E
Pausar	Esc

Clone o repositório:

git clone https://github.com/andersonsimplicio/ArthursKingdom3D.git

Entre na pasta do projeto:

cd SEU-REPOSITORIO


Depois:

Abra o Unity Hub.

Selecione Add / Adicionar projeto.

Escolha a pasta do projeto.

Abra o projeto utilizando a versão correta da Unity.

Abra a cena principal em Assets/Scenes/.

📸 Screenshots

Adicione aqui imagens do jogo:

📌 Status do projeto

🚧 Em desenvolvimento

 Configuração inicial do projeto

 Controle básico do personagem

 Sistema de combate

 Inimigos

 Interface

 Áudio

 Fase principal

 Build final

👤 Autor

Anderson José Simplício

GitHub: @andersonsimplicio

⭐ Se você gostou do projeto, considere deixar uma estrela no repositório!


🚀 Como baixar e executar o projeto
📋 Requisitos

Antes de baixar o projeto, instale:

Unity Hub

Git

Git LFS

Importante: utilize a mesma versão da Unity utilizada no desenvolvimento do projeto. A versão pode ser encontrada no arquivo ProjectSettings/ProjectVersion.txt.

Entre na pasta do projeto:

cd SEU-REPOSITORIO

📦 1. Configurar o Git LFS

Execute:

git lfs install


Depois baixe os arquivos grandes armazenados pelo Git LFS:

git lfs pull


O Git LFS é utilizado neste projeto para armazenar assets grandes, como texturas .psd e .tga.

🎮 2. Abrir o projeto no Unity

Abra o Unity Hub.

Clique em Add / Adicionar.

Selecione a pasta onde o projeto foi clonado.

Abra o projeto utilizando a versão correta da Unity.

Aguarde o Unity importar os assets. Na primeira abertura isso pode levar alguns minutos.

▶️ 3. Executar o jogo

Depois que o projeto terminar de importar:

Abra a cena principal em Assets/Scenes/.

Clique no botão Play no Unity.

Utilize os controles descritos na seção Controles deste README.

⚠️ Problemas comuns
Os modelos ou texturas aparecem faltando

Verifique se o Git LFS está instalado:

git lfs version

Depois execute:
git lfs pull
O Unity informa que a versão do projeto é diferente
Verifique a versão em:
ProjectSettings/ProjectVersion.txt
Utilize essa mesma versão pelo Unity Hub sempre que possível.
O projeto demora para abrir pela primeira vez
Isso é normal. O Unity precisa importar e processar os assets do projeto. O tempo depende do tamanho do projeto e do computador.