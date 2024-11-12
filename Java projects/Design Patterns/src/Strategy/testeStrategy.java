package Strategy;

import java.math.BigDecimal;

public class testeStrategy {
    public static void main(String[] args) {
        var funcionario1 = new Funcionario("João", TipoCargo.DESENVOLVEDOR, new BigDecimal(1000));
        var funcionario2 = new Funcionario("Maria", TipoCargo.DBA, new BigDecimal(1000));
        var funcionario3 = new Funcionario("José", TipoCargo.TESTER, new BigDecimal(1000));

        ReajusteAnual.reajuste(new CalculaReajusteDEV(), funcionario1);
        ReajusteAnual.reajuste(new CalculaReajusteDBA(), funcionario2);
        ReajusteAnual.reajuste(new CalculaReajusteTester(), funcionario3);

        System.out.println(funcionario1);
        System.out.println(funcionario2);
        System.out.println(funcionario3);

    }
}
