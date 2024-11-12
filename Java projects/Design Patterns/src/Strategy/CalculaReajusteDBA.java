package Strategy;

import java.math.BigDecimal;

public class CalculaReajusteDBA implements CalculaReajuste {

    @Override
    public void calcula(Funcionario funcionario) {
     var aumento = funcionario.getSalario().multiply(new BigDecimal("0.1"));
        funcionario.setSalario(funcionario.getSalario().add(aumento));
    }
}
