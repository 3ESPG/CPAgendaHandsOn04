# 📅 Agenda Console — Gerenciador de Compromissos com Timezone

> Projeto acadêmico desenvolvido para a disciplina de programação da FIAP.

---

## 📖 Sobre o Projeto

O **Agenda Console** é uma aplicação de console desenvolvida em **C# (.NET 8)** que permite ao usuário gerenciar compromissos com suporte completo a **fusos horários (timezones)**. O sistema armazena cada compromisso com sua data, hora e timezone de origem, e é capaz de exibir os compromissos convertidos para qualquer timezone informado pelo usuário.

---

## ✨ Funcionalidades

- ➕ **Adicionar compromisso** — cadastra descrição, data/hora e timezone do evento
- 📆 **Ver compromissos de hoje** — exibe os compromissos do dia atual no timezone do usuário
- 🔍 **Buscar por data** — filtra compromissos de uma data específica em qualquer timezone
- 🌍 **Alterar timezone do usuário** — muda o fuso horário de visualização sem alterar os dados salvos
- 📋 **Listar timezones disponíveis** — exibe todos os fusos horários reconhecidos pelo sistema

---

## 🧠 Conceitos Aplicados

| Conceito | Aplicação no projeto |
|---|---|
| `DateTimeOffset` | Armazena data/hora com offset, preservando o fuso original |
| `TimeZoneInfo` | Conversão entre fusos horários diferentes |
| `TimeZoneInfo.ConvertTime()` | Exibe o mesmo compromisso em timezones distintos |
| Orientação a Objetos | Classes `Compromisso` e `Agenda` com responsabilidades separadas |
| LINQ | Filtragem e ordenação dos compromissos por data |
| Top-level statements | Código principal enxuto no `Program.cs` |

---

## 🗂️ Estrutura do Projeto

```
AgendaConsole/
├── AgendaConsole.csproj   # Configuração do projeto .NET
├── Program.cs             # Ponto de entrada e menu interativo
├── Compromisso.cs         # Modelo de dados do compromisso
└── Agenda.cs              # Lógica de armazenamento e consulta
```

---

## 🚀 Como Executar

### Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download) instalado

### Passos

```bash
# Clone o repositório
git clone https://github.com/SEU_USUARIO/agenda-console-csharp.git

# Entre na pasta do projeto
cd agenda-console-csharp/AgendaConsole

# Execute a aplicação
dotnet run
```

---

## 🖥️ Exemplo de Uso

```
╔══════════════════════════════════╗
║       AGENDA DE COMPROMISSOS      ║
╚══════════════════════════════════╝
Timezone do sistema: E. South America Standard Time

┌─────────────────────────────────┐
│            MENU                 │
│  1 - Adicionar compromisso      │
│  2 - Ver compromissos de hoje   │
│  3 - Ver por data               │
│  4 - Alterar meu timezone       │
│  5 - Listar timezones           │
│  0 - Sair                       │
└─────────────────────────────────┘
Escolha: 1

── NOVO COMPROMISSO ──
Descrição: Reunião com equipe
Data e hora (dd/MM/yyyy HH:mm): 28/04/2025 14:00
Timezone do compromisso: E. South America Standard Time
✔ Compromisso adicionado com sucesso!
```

---

## 🌐 Timezones Comuns

| Cidade | Timezone ID (Windows) |
|---|---|
| São Paulo / Brasília | `E. South America Standard Time` |
| Lisboa | `GMT Standard Time` |
| Nova York | `Eastern Standard Time` |
| Londres | `UTC` |
| Tóquio | `Tokyo Standard Time` |

> 💡 Use a opção **5 do menu** para listar todos os timezones disponíveis no sistema.

---

## 👨‍💻 Integrantes

Projeto desenvolvido por alunos da **FIAP**:

| Nome | RM |
|---|---|
| Felipe Braunstein e Silva | RM554483 |
| Felipe do Nascimento Fernandes | RM554598 |
| Henrique Ignacio Bartalo | RM555274 |
| Gustavo Henrique Martins | RM556956 |

---

## 🏫 Informações Acadêmicas

- **Instituição:** FIAP — Faculdade de Informática e Administração Paulista
- **Linguagem:** C# (.NET 8)
- **Tipo:** Projeto Acadêmico

---

*Desenvolvido com 💙 pela equipe — FIAP*
