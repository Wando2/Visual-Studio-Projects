package proxy;

import builder.person;

public class proxyTeste {
    public static void main(String[] args) {
        person p = new person.Builder()
                .name("John")
                .surname("Doe")
                .age(30)
                .build();

        var personRepository = new PRepositoryProxy();
        var personService = new PersonService(personRepository);

        personService.save(p);

        System.out.println(personService.get(0L));

    }
}
