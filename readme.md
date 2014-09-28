This is a set of experiments to allow a single set of azure roles to have a set of tasks partitioned around them fairly.
In addition there must not be excessive communication between the nodes and it must be able to survive node failures (upto and including a full redeploy).

Currently I have sample code that allows a master to be selected between N nodes.
There are currently two actions covered:

Selection of Master:
1. Select a master based upon a file lock.
2. Select a master based upon a Redis Lock
3. TBA Select a master based upon locking an element in azure blob storage.

Pub/Sub example using Redis:
The master is able to broadcast to all of the slave nodes.
This is resiliant across the failure of the master.