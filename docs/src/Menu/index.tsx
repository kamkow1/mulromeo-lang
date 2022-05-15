import { Menu } from "@mantine/core";
import React from "react";

interface Props {
    name: string
    items: string[]
}

export default function Index(props: Props) {
    return (
        <Menu>
            <Menu.Label>{props.name}</Menu.Label>
            <React.Fragment>
                {props.items.map((v, i) => {
                    return <Menu.Item key={i}>{v}</Menu.Item>
                })}
            </React.Fragment>
        </Menu>
    )
}