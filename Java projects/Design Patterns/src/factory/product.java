package factory;

import java.math.BigDecimal;

public class product {
    private String Name;
    private BigDecimal price;
    private Enum<productType> typeProduct;
    private Boolean hasPhysicalDimensions;

    @Override
    public String toString() {
        return String.format("product{Name='%s', price=%s, typeProduct=%s}", Name, price, typeProduct);
    }

    public String getName() {
        return Name;
    }

    public Boolean getHasPhysicalDimensions() {
        return hasPhysicalDimensions;
    }

    public void setHasPhysicalDimensions(Boolean hasPhysicalDimensions) {
        this.hasPhysicalDimensions = hasPhysicalDimensions;
    }
    public void setName(String name) {
        Name = name;
    }

    public BigDecimal getPrice() {
        return price;
    }



    public void setPrice(BigDecimal price) {
        this.price = price;
    }

    public Enum<productType> getTypeProduct() {
        return typeProduct;
    }

    public void setTypeProduct(Enum<productType> typeProduct) {
        this.typeProduct = typeProduct;
    }
}
