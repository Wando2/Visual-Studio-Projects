package Strategy;

import java.math.BigDecimal;

public class CalculaReajusteDEV implements CalculaReajuste{

        @Override
        public void calcula(Funcionario funcionario) {
            if (funcionario.getSalario().compareTo(new BigDecimal("3000")) > 0) {
                funcionario.setSalario(funcionario.getSalario().multiply(new BigDecimal("1.1")));
            } else {
                funcionario.setSalario(funcionario.getSalario().multiply(new BigDecimal("1.2")));
            }
        }
}
