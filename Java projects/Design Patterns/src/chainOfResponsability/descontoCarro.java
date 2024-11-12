package chainOfResponsability;

import java.math.BigDecimal;

public abstract class descontoCarro {
    protected descontoCarro proximo;

    public descontoCarro(descontoCarro proximo) {
        this.proximo = proximo;
    }

    public abstract BigDecimal desconta(carro carro);
}
