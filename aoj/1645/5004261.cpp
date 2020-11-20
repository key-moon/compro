// detail: https://onlinejudge.u-aizu.ac.jp/status/users/keymoon/submissions/1/1645/judge/5004261/C++17
#include <bits/stdc++.h>
using namespace std;

template<class T, T& (*merge)(T&, T&)>
struct UnionFind{
  vector<T> data;
  vector<int> parent;
  vector<int> size;
  
  UnionFind(vector<T> &v): data(v), parent(v.size()), size(v.size(), 1){
    iota(parent.begin(), parent.end(), 0);
  }
  
  T& operator[](int i){return data[find(i)];}
  int find(int x){
    return x == parent[x] ? x : parent[x] = find(parent[x]);
  }
  bool unite(int x, int y){
    int xp = find(x), yp = find(y);
    if (xp == yp) return false;
    if (size[xp] < size[yp]) swap(xp, yp);
    parent[yp] = xp;
    data[xp] = merge(data[xp], data[yp]);
    size[xp] += size[yp];
    return true;
  }
};

const int INF = INT32_MAX / 2;
struct Group{
  using P = pair<int, int>;

  //{(1,2),(2,5),(5,6)}: 1が2まで, 2が5まで, 5が6まで
  //0 1 2 3 4 5 6
  //-------------
  //1 1 1 2 2 2 5
  vector<P> data;
  vector<int> cand;
  Group(){}
  Group(int i): data{P(INF, 1)}, cand{i}{}

  void add(int at, int num){
    if (data.back().first == at){
      data.back().second = num;
    }
    else{
      data.emplace_back(at, num);
    }
  }
  //グループのサイズ
  int cnt(){
    return data.back().second;
  }
  // a < b -> -1
  // a > b -> 1
  static int compare(Group& a, Group& b){
    int cur = 0;
    int aind = a.data.size() - 1;
    int bind = b.data.size() - 1;
    while (0 <= aind && 0 <= bind){
      int apos = a[aind].first, bpos = b[bind].first;
      int aval = a[aind].second, bval = b[bind].second;
      if (aval == bval){
        //aの方が先に小さくなる→aの方が小さい(単調減少性より)
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

  P operator[](int k){return data[k];}
};

int current;
Group& merge(Group& l, Group& r){
  int cnt = l.cnt() + r.cnt();
  l.add(current, cnt);
  r.add(current, cnt);

  int cmp = Group::compare(l, r);
  // l < r
  if (cmp < 0) return r;
  // l > r
  if (cmp > 0) return l;
  if (cmp == 0){
    if (l.cand.size() < r.cand.size()) swap(l.cand, r.cand);
    for (auto&& elem : r.cand){
      l.cand.emplace_back(elem);
    }
    return l;
  }
  assert(false);
}

struct Edge{
  int from;
  int to;
  int value;
  Edge(int from, int to, int value): from(from), to(to), value(value) {}
};

bool solve(){
  int n, m;
  cin >> n >> m;
  if (n == 0) return false;
  vector<Edge> edges{};
  for (int i = 0; i < m; i++){
    int a, b, s;
    cin >> a >> b >> s;
    a--, b--;
    edges.emplace_back(a, b, s);
  }
  sort(edges.begin(), edges.end(), [](Edge a, Edge b){
    return a.value > b.value;
  });
  
  vector<Group> groups{};
  for (int i = 0; i < n; i++) groups.emplace_back(i);

  UnionFind<Group, merge> uf(groups);

  for (auto&& edge : edges){
    int s = edge.from, t = edge.to, c = edge.value;
    current = c;
    uf.unite(s, t);
  }
  
  vector<int>& res = uf[0].cand;
  sort(res.begin(), res.end());
  for (int i = 0; i < res.size(); i++){
    if (i != 0) cout << ' ';
    cout << res[i] + 1;
  }
  cout << '\n';
  return true;
}

int main(){
  cin.tie(nullptr);
  ios::sync_with_stdio(false);
  while (solve());
  return 0;
}
