import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Button from '@material-ui/core/Button';
import Typography from '@material-ui/core/Typography';

export interface Props {
  image: string,
  title: string,
  description: string
}

export default function TeamCard(props: Props) {
  const classes = useStyles();

  return (
    <Card className={classes.cardRoot}>
      <CardActionArea>
        <CardMedia
          component="img"
          alt={props.title}
          height="140"
          //image={props.image}
          src={props.image}
          title={props.title}
        />
        <CardContent>
          <Typography gutterBottom variant="h5" component="h2">
            {props.title}
          </Typography>
          <Typography variant="body2" color="textSecondary" component="p">
           {
             props.description
           }
          </Typography>
        </CardContent>
      </CardActionArea>
      <CardActions>
        <Button size="small" color="primary">
          Assign To Stadium
        </Button>
        <Button size="small" color="primary">
          Learn More
        </Button>
      </CardActions>
    </Card>
  );
}

const useStyles = makeStyles({
  cardRoot: {
    maxWidth: '100%',
  },
});