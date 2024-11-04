package Prototype;

public class bottonFactory {

    public static botton getInstance(botton prototype){
        return new botton(prototype.color, prototype.width, prototype.height, prototype.type);
    }
}
