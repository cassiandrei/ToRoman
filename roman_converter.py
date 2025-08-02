def to_roman(num):
    """
    Converte um número inteiro (1-3999) para algarismos romanos.

    Args:
        num (int): Número inteiro a ser convertido

    Returns:
        str: Representação em algarismos romanos
    """
    if not isinstance(num, int) or num < 1 or num > 3999:
        raise ValueError("Número deve ser um inteiro entre 1 e 3999")

    # Mapeamento de valores decimais para romanos em ordem decrescente
    valores = [
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I"),
    ]

    resultado = ""

    for valor, simbolo in valores:
        while num >= valor:
            resultado += simbolo
            num -= valor

    return resultado


def testar_com_arquivo():
    """
    Lê o arquivo de teste e verifica se o método to_roman está funcionando corretamente.
    """
    arquivo_teste = "decimais_romanos_1_a_3999.txt"

    try:
        with open(arquivo_teste, "r", encoding="utf-8") as arquivo:
            linhas = arquivo.readlines()

        print(f"Testando {len(linhas)} conversões...")
        print("-" * 50)

        erros = 0
        sucessos = 0

        for i, linha in enumerate(linhas, 1):
            linha = linha.strip()
            if not linha:
                continue

            partes = linha.split(" ", 1)
            if len(partes) != 2:
                print(f"Linha {i} inválida: {linha}")
                continue

            try:
                numero = int(partes[0])
                romano_esperado = partes[1]
                romano_calculado = to_roman(numero)

                if romano_calculado == romano_esperado:
                    sucessos += 1
                    if (
                        i <= 10 or i % 100 == 0
                    ):  # Mostra os primeiros 10 e depois a cada 100
                        print(f"✓ {numero} → {romano_calculado}")
                else:
                    erros += 1
                    print(
                        f"✗ {numero}: esperado '{romano_esperado}', obtido '{romano_calculado}'"
                    )

            except ValueError as e:
                erros += 1
                print(f"Erro na linha {i}: {e}")

        print("-" * 50)
        print(f"Resultados do teste:")
        print(f"✓ Sucessos: {sucessos}")
        print(f"✗ Erros: {erros}")
        print(f"Total: {sucessos + erros}")

        if erros == 0:
            print(
                "\n🎉 Todos os testes passaram! O método to_roman está funcionando corretamente."
            )
        else:
            print(f"\n⚠️  {erros} testes falharam. Verifique a implementação.")

    except FileNotFoundError:
        print(f"Arquivo '{arquivo_teste}' não encontrado!")
    except Exception as e:
        print(f"Erro ao processar arquivo: {e}")



if __name__ == "__main__":
    print("=== Conversor de Números para Algarismos Romanos ===\n")

    # Executar testes com o arquivo
    testar_com_arquivo()
