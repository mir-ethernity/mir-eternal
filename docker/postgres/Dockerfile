FROM postgres:13

ENV TZ Europe/Madrid

RUN apt-get update \
    && apt-get install -y --no-install-recommends \
    postgresql-13-postgis-3 \
    postgresql-13-postgis-3-scripts \ 
    supervisor \
    cron

RUN touch /var/log/postgresql/supervisor_postgresql.log

# set time zone
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone


# add backup job
RUN mkdir -p /opt/backups  && chown -R 999:999 "/opt/backups"
COPY ./pgbackup.sh /opt/pgbackup.sh
RUN chmod +x /opt/pgbackup.sh

# add init script
RUN mkdir -p /docker-entrypoint-initdb.d
COPY ./initdb-postgis.sh /docker-entrypoint-initdb.d/postgis.sh

# add cron files
COPY ./backup-cron /etc/cron.d/backup-cron
RUN crontab /etc/cron.d/backup-cron

# add supervisor files
COPY ./supervisord.conf /etc/supervisord.conf

# create volume for backups
VOLUME ["/opt/backups"]

ENTRYPOINT ["/usr/bin/supervisord", "-c", "/etc/supervisord.conf"]
# CMD tail -f /var/log/postgresql/supervisor_postgresql.log