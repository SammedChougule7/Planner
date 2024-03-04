import { Card, CardContent, Checkbox, FormControlLabel } from '@mui/material';
import { useState } from 'react';

const TaskCard = ({ id, title="Title of the task", dueDate, status }) => {
    const [checked, setChecked] = useState<boolean>(status);

    const handleChange = (event: React.ChangeEvent<HTMLInputElement>) => {
        setChecked(event.target.checked);
    };

    return (
        <Card sx={{ maxWidth: 300 }} className='m-2'>
            <CardContent className='text-justify'>
                <div className='pb-2 inline'>
                    <FormControlLabel
                        value="top"
                        control={<Checkbox
                            checked={checked}
                            onChange={handleChange}
                        />}
                        label={title}
                        labelPlacement="end"
                    />                    
                </div>
                <div className='border-t pt-2'>
                    <p>{dueDate || "Due"}</p>
                </div>
            </CardContent>
        </Card>
    )
}

export default TaskCard