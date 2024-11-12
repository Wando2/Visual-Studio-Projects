package Strategy;

import java.math.BigDecimal;

public class Funcionario {
    private String nome;
    private Enum<TipoCargo> cargo;
    private BigDecimal salario;

    public Funcionario(String nome, Enum<TipoCargo> cargo, BigDecimal salario) {
        this.nome = nome;
        this.cargo = cargo;
        this.salario = salario;
    }

    public String getNome() {
        return nome;
    }

    public Enum<TipoCargo> getCargo() {
        return cargo;
    }

    public BigDecimal getSalario() {
        return salario;
    }

    public void setNome(String nome) {
        this.nome = nome;
    }

    public void setCargo(Enum<TipoCargo> cargo) {
        this.cargo = cargo;
    }

    public void setSalario(BigDecimal salario) {
        this.salario = salario;
    }

    @Override
    public String toString() {
        return "Funcionario{" +
                "nome='" + nome + '\'' +
                ", cargo=" + cargo +
                ", salario=" + salario +
                '}';
    }
}
