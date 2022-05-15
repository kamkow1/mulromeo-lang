import { ActionIcon, Text } from "@mantine/core"
import { useHover } from "@mantine/hooks"
import { FileText, Code, BrandGithub } from "tabler-icons-react"
import Menu from '../Menu'

interface Props {
    text: string
    menuItems: string[]
    menuHeader: string
    iconType: 'fileText' | 'code' | 'github'
}

function renderIcon(
    icon: string,
    menuWindow: JSX.Element,
    hovered: boolean) {
    switch (icon) {
        case 'fileText':
            return <> <FileText /> {hovered ? menuWindow : ''} </>
        case 'code':
            return <> <Code /> {hovered ? menuWindow : ''} </>
        case 'github':
            return <> <BrandGithub /> {hovered ? menuWindow : ''} </>
    }
}

export default function NavbarElement(props: Props) {
    const { hovered, ref } = useHover()

    return (
        <div style={{ display: 'flex', justifyContent: 'center' }}>
            <Text
                color='blue'
                size='lg'
                style={{ width: '100%', float: 'left', marginLeft: '25px' }}
            >
                {props.text}
            </Text>
            <div style={{ marginRight: '25px', display: 'flex' }} ref={ref}>
                <ActionIcon 
                    color='cyan' 
                    variant='transparent'
                >
                    {renderIcon(props.iconType, 
                    <Menu name={props.menuHeader} items={props.menuItems} />, 
                    hovered)}
                </ActionIcon>
            </div>
        </div>
    )
}