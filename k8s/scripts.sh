podman machine start
podman build -t ghcr.io/salatielbairros/oldapp:latest -f OldApp\Dockerfile . 
podman push ghcr.io/salatielbairros/oldapp:latest    
kubectl apply -f k8s/old/deployment.yaml
kubectl apply -f k8s/old/service.yaml