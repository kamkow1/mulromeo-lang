import { Group, Navbar } from "@mantine/core"
import NavbarElement from './NavbarElement'

export default function Index() {
    return (
        <Navbar width={{ base: '250px' }} height='100vh'>
            <Group
                spacing='md'
                grow
                direction='column'
            >
                <Navbar.Section>
                    <NavbarElement 
                        text='dokumentacja'
                        menuHeader='przejdź do rozdziału'
                        iconType='fileText'
                        menuItems={[
                            'składnia',
                            'operatory',
                            'typy danych',
                            'zmienne',
                            'operacje matematyczne',
                            'operacje na stringach',
                            'wbudowane funkcje',
                            'własne funkcje',
                            'pętle',
                            'uwalnianie pamięci'
                        ]}
                    />
                </Navbar.Section>
                <Navbar.Section>
                    <NavbarElement 
                        text='interpreter'
                        menuHeader='przejdź do rozdziału'
                        iconType='code'
                        menuItems={[
                            'lexer',
                            'parser',
                            'visitor',
                            'operacje na stringach',
                            'wbudowane funkcje',
                            'własne funkcje',
                            'pętle',
                            'uwalnianie pamięci'
                        ]}
                    />
                </Navbar.Section>
                <Navbar.Section>
                    <NavbarElement 
                        text='dołącz do nas'
                        menuHeader='przejdź do rozdziału'
                        iconType='github'
                        menuItems={[
                            'github',
                            'discord',
                            'kontakt'
                        ]}
                    />
                </Navbar.Section>
            </Group>
        </Navbar>
    )
}