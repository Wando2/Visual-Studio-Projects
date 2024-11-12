package chainOfResponsability;

import java.math.BigDecimal;

public class carro {
    BigDecimal valor;
    Enum<TipoCarro> tipo;

    public carro(BigDecimal valor, Enum<TipoCarro> tipo) {
        this.valor = valor;
        this.tipo = tipo;
    }

    public BigDecimal getValor() {
        return valor;
    }

    public void setValor(BigDecimal valor) {
        this.valor = valor;
    }

    public Enum<TipoCarro> getTipo() {
        return tipo;
    }

    public void setTipo(Enum<TipoCarro> tipo) {
        this.tipo = tipo;
    }
}
