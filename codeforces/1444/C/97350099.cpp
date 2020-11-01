// detail: https://codeforces.com/contest/1444/submission/97350099
#include <bits/stdc++.h>
using namespace std;

using ll = long long;
#define var auto

const char newl = '\n';

template< typename T1, typename T2 >
inline void chmin(T1 &a, T2 b) { if (a > b) a = b; }
template< typename T1, typename T2 >
inline void chmax(T1 &a, T2 b) { if (a < b) a = b; }

signed main() {
  cin.tie(0);
  ios::sync_with_stdio(0);
  int n, m, k;
  cin >> n >> m >> k;
  vector<int> color(n);
  for (int i = 0; i < n; i++){
    cin >> color[i];
    color[i]--;
  }
  using P = pair<int, int>;
  map<P, vector<P>> colEdges{};
  vector<vector<int>> graph(n, vector<int>());
  for (int i = 0; i < m; i++){
    int s, t;
    cin >> s >> t;
    s--; t--;
    graph[s].push_back(t);
    graph[t].push_back(s);
    var cols = color[s];
    var colt = color[t];
    if (cols > colt) swap(cols, colt);
    colEdges[P(cols, colt)].emplace_back(s, t);
  }
  vector<bool> isBiparate(k, true);
  vector<int> newVerts(n, -1);
  int curVertCnt = 0;
  for (int i = 0; i < n; i++){
    if (newVerts[i] != -1 || !isBiparate[color[i]]) continue;
    stack<int> stack{};
    stack.push(i);
    newVerts[i] = curVertCnt;
    while (!stack.empty()){
      var node = stack.top(); stack.pop();
      for (var&& adj : graph[node]){
        if (color[adj] != color[node]) continue;
        if (newVerts[adj] == (newVerts[node] ^ 1)) continue;
        if (newVerts[adj] == newVerts[node]){
          isBiparate[color[adj]] = false;
          goto end;
        }
        stack.push(adj);
        newVerts[adj] = newVerts[node] ^ 1;
      }
    }

    end:;
    curVertCnt += 2;
  }

  vector<int> colors(curVertCnt);
  vector<vector<int>> newGraph(curVertCnt, vector<int>());
  int cantMake = 0;
  //全登場色ペアについて、新しくグラフを構築する List で毎回終わったら使った頂点だけclear
  for (var&& colEdge : colEdges){
    unordered_set<int> verts{};
    var [cols, edges] = colEdge;
    var [cola, colb] = cols;
    if (!isBiparate[cola] || !isBiparate[colb]) continue;
    for (var&& edge : edges){
      var [s, t] = edge;
      verts.insert(newVerts[s]);
      verts.insert(newVerts[t]);
      newGraph[newVerts[s]].push_back(newVerts[t]);
      newGraph[newVerts[t]].push_back(newVerts[s]);
    }
    stack<int> stack{};

    for (var&& vert : verts){
      if (colors[vert] != 0) continue;
      stack.push(vert);
      colors[vert] = 1;
      while (!stack.empty()){
        var elem = stack.top(); stack.pop();
        //xorが1の頂点へのDFSを忘れずに
        for (var&& adj : newGraph[elem]){
          if (colors[adj] != 0){
            if (colors[adj] == -colors[elem]) continue;
            if (colors[adj] == colors[elem]){
              cantMake++;
              goto _end;
            }
          }
          stack.push(adj);
          colors[adj] = -colors[elem];
        }
        {
          if (colors[elem ^ 1] != 0){
            if (colors[elem ^ 1] == -colors[elem]) continue;
            if (colors[elem ^ 1] == colors[elem]){
              cantMake++;
              goto _end;
            }
          }
          stack.push(elem ^ 1);
          colors[elem ^ 1] = -colors[elem];
        }
      }
    }
    _end:;
    for (var&& vert : verts){
      colors[vert] = 0;
      colors[vert ^ 1] = 0;
      newGraph[vert].clear();
    }
  }
  ll validColor = 0;
  for (int i = 0; i < k; i++){
    if (isBiparate[i]) validColor++;
  }
  var total = (long)validColor * (validColor - 1) / 2;
  cout << (total - cantMake) << endl;
  return 0;
}
