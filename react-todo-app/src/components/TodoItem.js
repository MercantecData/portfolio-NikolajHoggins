import React, { Component } from 'react'

class TodoItem extends Component {
    render() {
        return (
            <div>
                <h3>{this.props.todo.title}</h3>
        <p>{this.props.todo.id}: {String(this.props.todo.completed)}</p>
            </div>
        )
    }
}

export default TodoItem
