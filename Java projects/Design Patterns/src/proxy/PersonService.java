package proxy;

import builder.person;

public class PersonService {
    private PersonRepository personRepository;

    public PersonService(PersonRepository personRepository){
        this.personRepository = personRepository;
    }

    public void save(person pessoa){
        personRepository.save(pessoa);
    }

    public person get(Long id){
        return personRepository.get(id);
    }
}
