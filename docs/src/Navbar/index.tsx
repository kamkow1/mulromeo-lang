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
                    />
                </Navbar.Section>
            </Group>
        </Navbar>
    )
}