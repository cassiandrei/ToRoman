# Conversor de Números para Algarismos Romanos

Este projeto contém implementações de um conversor de números inteiros para algarismos romanos em **Python** e **C# (.NET)**, além de um arquivo de teste com todos os números de 1 a 3999 e suas representações romanas.

## Pré-requisitos

- **Python 3.7+**
- **.NET SDK 6.0+** (recomendado .NET 8)

O arquivo de teste `decimais_romanos_1_a_3999.txt` deve estar no mesmo diretório dos códigos.

---

## Como executar em Python

1. Abra o terminal e navegue até a pasta do projeto:

   ```bash
   cd .../ToRoman
   ```

2. Execute o script Python:

   ```bash
   python roman_converter.py
   ```

O script irá mostrar exemplos de conversão e testar todas as 3999 combinações do arquivo de teste.

---

## Como executar em C# (.NET)

1. Abra o terminal e navegue até a pasta do projeto:

   ```bash
   cd .../ToRoman
   ```

2. Execute o projeto com o comando:

   ```bash
   dotnet run
   ```

   Ou, se preferir, especifique o projeto:

   ```bash
   dotnet run --project RomanConverter.csproj
   ```

O programa irá mostrar exemplos de conversão e testar todas as 3999 combinações do arquivo de teste.

---

## Estrutura dos arquivos

- `roman_converter.py` — Implementação em Python
- `RomanConverter.cs` — Implementação em C#
- `RomanConverter.csproj` — Projeto .NET
- `decimais_romanos_1_a_3999.txt` — Arquivo de teste (número e romano por linha)

---

## Observações

- O arquivo de teste é essencial para validar a implementação.
- Ambos os códigos exibem o resultado dos testes e exemplos no terminal.
- Se precisar instalar o .NET SDK, acesse: https://dotnet.microsoft.com/download
- Se precisar instalar o Python, acesse: https://www.python.org/downloads/
# ToRoman
