import { Button, Header, Text } from "@mantine/core";
import { useNavigate } from "react-router-dom";

export default function Index() {
    let navigate = useNavigate()

    return (
        <Header height='68' p='md'>
            <Button
                variant='subtle' 
                color='dark'
                radius='xs'
                onClick={() => navigate('/', { replace: true })}
            >
                <Text 
                    color='dimmed'
                    size='lg'
                >
                    mulromeo-lang
                </Text>
            </Button>
        </Header>
    )
}