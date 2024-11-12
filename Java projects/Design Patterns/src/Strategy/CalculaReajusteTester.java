package Strategy;

import java.math.BigDecimal;

public class CalculaReajusteTester implements  CalculaReajuste{

    @Override
    public void calcula(Funcionario funcionario) {
        var aumento = funcionario.getSalario().multiply(new BigDecimal("0.2"));
        funcionario.setSalario(funcionario.getSalario().add(aumento));
    }
}
