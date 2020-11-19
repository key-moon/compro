// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1645/judge/5001310/C++17
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template<typename T1, typename T2>
inline bool chmin(T1 &a, T2 b) { bool c = a > b; if (c) a = b; return c; }
template<typename T1, typename T2>
inline bool chmax(T1 &a, T2 b) { bool c = a < b; if (c) a = b; return c; }

struct Edge{
  int from;
  int to;
  int cost;
  Edge(int from, int to, int cost):from(from), to(to), cost(cost){}
};

struct Group{
  //強度iが落ちる前の本数j
  using P = pair<int, int>;
  vector<P> data{};
  vector<int> cand{};
  Group(){}
  Group(int mx, int i){
    data.emplace_back(mx, 1);
    cand.emplace_back(i);
  }

  void add(int at, int num){
    if (data.back().first == at){
      data.back().second = num;
    }
    else{
      data.emplace_back(at, num);
    }
  }

  int cnt(){
    return data.back().second;
  }

  P operator[](int k){return data[k];}

  //(1,2),(2,5),(5,6)
  //0 1 2 3 4 5 6
  //-------------
  //1 1 1 2 2 2 5
  //
  // a < b -> -1
  // a > b -> 1
  static int compare(Group& a, Group& b){
    int cur = 0;
    int aind = a.data.size() - 1;
    int bind = b.data.size() - 1;
    while (0 <= aind && 0 <= bind){
      var apos = a[aind].first, bpos = b[bind].first;
      var aval = a[aind].second, bval = b[bind].second;
      if (aval == bval){
        //aの方が先に小さくなる→aの方が小さい
        if (apos < bpos) return -1;
        if (apos > bpos) return 1;
      }
      else{
        //aの方が値が小さい→aの方が小さい
        if (aval < bval) return -1;
        if (aval > bval) return 1;
      }
      aind--; bind--;
    }
    return 0;
  }
};

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, m;
  while (cin >> n >> m, n){
    vector<Edge> edges{};
    for (int i = 0; i < m; i++){
      int a, b, s;
      cin >> a >> b >> s;
      a--, b--;
      edges.emplace_back(a, b, s);
    }
    sort(edges.begin(), edges.end(), [](Edge a, Edge b){
      return a.cost > b.cost;
    });
    
    vector<Group> group{};
    for (int i = 0; i < n; i++){
      group.emplace_back(100001, i);
    }

    vector<int> groupID(n);
    iota(groupID.begin(), groupID.end(), 0);

    var getid = [&](int i){
      vector<int> par{};
      int id;
      while (groupID[i] != i){
        par.emplace_back(i);
        i = groupID[i];
      }
      id = i;
      for (var&& item : par) groupID[item] = id;
      return id;
    };


    for (var&& edge : edges){
      var s = edge.from, t = edge.to, c = edge.cost;
      var sid = getid(s);
      var tid = getid(t);
      if (sid == tid) continue;

      var cnt = group[sid].cnt() + group[tid].cnt();
      group[sid].add(c, cnt);
      group[tid].add(c, cnt);

      var cmp = Group::compare(group[sid], group[tid]);

      int winid, loseid, winelem, loseelem;
      //g[s] < g[t]
      if (cmp < 0){
        winid = tid, loseid = sid;
        winelem = t, loseelem = s;
      }
      else{
        winid = sid, loseid = tid;
        winelem = s, loseelem = t;
      }
      groupID[loseid] = winid;
      
      if (cmp == 0){
        for (var elem : group[loseid].cand){
          group[winid].cand.emplace_back(elem);
        }
      }
      var none = 1 + 1;
    }
    
    var top = getid(0);
    for (int i = 0; i < n; i++){
      assert(getid(i) == top);
    }

    var res = group[top].cand;
    sort(res.begin(), res.end());
    for (int i = 0; i < res.size(); i++){
      if (i != 0) cout << " ";
      cout << res[i] + 1;
    }
    cout << endl;
  }
  return 0;
}
