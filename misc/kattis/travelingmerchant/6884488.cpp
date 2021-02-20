#include<bits/stdc++.h>

using ll = long long;
#define var auto

using namespace std;

template<typename T1, typename T2> inline void chmin(T1& a, T2 b) { if (a > b) a = b; }
template<typename T1, typename T2> inline void chmax(T1& a, T2 b) { if (a < b) a = b; }

int mul[7] = { 0, 1, 2, 3, 2, 1, 0 };

struct Query {
  int ind;
  int s;
  int t;
};

int main() {
  int n;
  cin >> n;
  using P = pair<ll, ll>;
  vector<P> vds(n);
  for (int i = 0; i < n; i++) cin >> vds[i].first >> vds[i].second;
  vector<vector<ll>> seqs(14, vector<ll>(n));
  for (int i = 0; i < 7; i++) {
    for (int j = 0; j < n; j++) {
      seqs[i][j] = vds[j].first + vds[j].second * mul[(i + j) % 7];
    }
  }
  for (int i = 0; i < 7; i++) {
    for (int j = 0; j < n; j++) {
      seqs[7 + i][j] = vds[n - 1 - j].first + vds[n - 1 - j].second * mul[(i + j) % 7];
    }
  }

  int q;
  cin >> q;
  vector<vector<Query>> queries(14, vector<Query>{});
  for (int i = 0; i < q; i++) {
    Query q;
    q.ind = i;
    cin >> q.s >> q.t;
    q.s--; q.t--;
    int id = 0;
    if (q.s > q.t) { // backward
      id += 7;
      q.s = n - 1 - q.s;
      q.t = n - 1 - q.t;
    }
    id += ((-q.s) % 7 + 7) % 7;
    queries[id].emplace_back(q);
  }

  vector<ll> res(q, -1);
  var stupid = [&](Query q, vector<ll>& seq) {
    ll curres = 0;
    ll curmn = INT_MAX;
    for (int i = q.s; i <= q.t; i++) {
      chmin(curmn, seq[i]);
      chmax(curres, seq[i] - curmn);
    }
    return curres;
  };
  for (int ind = 0; ind < 14; ind++) {
    var qs = queries[ind];
    var seq = seqs[ind];
    const int PACKET = 512;
    int sz = n / PACKET;
    vector<vector<Query>> packets(sz, vector<Query>{});
    for (var&& q : qs) {
      if (q.t - q.s <= PACKET) res[q.ind] = stupid(q, seq);
      else packets[q.s / PACKET].emplace_back(q);
    }
    for (int i = 0; i < sz; i++) {
      sort(packets[i].begin(), packets[i].end(), [](Query a, Query b) { return b.t > a.t; });
      ll bigres = 0;
      ll bigmx = 0;
      ll bigmn = INT_MAX;
      int cur = (i + 1) * PACKET;
      for (var&& q : packets[i]) {
        while (cur <= q.t) {
          chmin(bigmn, seq[cur]);
          chmax(bigres, seq[cur] - bigmn);
          chmax(bigmx, seq[cur]);
          cur++;
        }
        ll curres = bigres;
        ll curmx = bigmx;
        for (int j = (i + 1) * PACKET - 1; j >= q.s; j--) {
          chmax(curres, curmx - seq[j]);
          chmax(curmx, seq[j]);
        }
        //var ans = stupid(q, seq);
        //assert(curres == ans);
        res[q.ind] = curres;
      }
    }
  }
  for (int i = 0; i < q; i++) cout << res[i] << endl;
}
