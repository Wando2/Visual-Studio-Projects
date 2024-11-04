package Prototype;

public class botton {
    protected String color;
    protected int width;
    protected int height;
    protected Enum<ButtonType> type;

    public String getColor() {
        return color;
    }

    public void setColor(String color) {
        this.color = color;
    }

    public int getWidth() {
        return width;
    }

    public void setWidth(int width) {
        this.width = width;
    }

    public int getHeight() {
        return height;
    }

    public void setHeight(int height) {
        this.height = height;
    }

    public Enum<ButtonType> getType() {
        return type;
    }

    public void setType(Enum<ButtonType> type) {
        this.type = type;
    }

    public botton(String color, int width, int height, Enum<ButtonType> type) {
        this.color = color;
        this.width = width;
        this.height = height;
        this.type = type;
    }
}
