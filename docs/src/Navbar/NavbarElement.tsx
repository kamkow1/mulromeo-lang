import { Text } from "@mantine/core"
import Menu from '../Menu'

interface Props {
    text: string
}

export default function NavbarElement(props: Props) {
    return (
        <div style={{ display: 'flex', justifyContent: 'center' }}>
            <Text
                color='indigo'
                size='lg'
            >
                {props.text}
            </Text>
            <Menu name='eo' items={['sg', 'ss', 'sss']} />
        </div>
    )
}