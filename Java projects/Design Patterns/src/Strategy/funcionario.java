package Strategy;

import java.math.BigDecimal;

public class funcionario {
    private String nome;
    private Enum<TipoCargo> cargo;
    private BigDecimal salario;

    public funcionario(String nome, Enum<TipoCargo> cargo, BigDecimal salario) {
        this.nome = nome;
        this.cargo = cargo;
        this.salario = salario;
    }
}
