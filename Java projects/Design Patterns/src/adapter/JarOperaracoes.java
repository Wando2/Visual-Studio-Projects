package adapter;

import java.math.BigDecimal;

public class JarOperaracoes {

    private BigDecimal saldo;

    public void deposito(BigDecimal valor){
        saldo = saldo.add(valor);
        System.out.println("Deposito de: " + valor + " realizado com sucesso!, seu saldo atual é: " + saldo);


    }

    public Boolean validacao(BigDecimal valor){
      return saldo.compareTo(valor) >= 0;
    }

    public void saque(BigDecimal valor){
       //validacao foi adaptado
        if(validacao(valor)){
            saldo = saldo.subtract(valor);
            System.out.println("Saque de: " + valor + " realizado com sucesso!, seu saldo atual é: " + saldo);
        } else {
            System.out.println("Saldo insuficiente para realizar o saque!");
        }
    }
}
